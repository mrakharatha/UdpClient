using System;
using System.Net;
using System.Text;

namespace UdpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // مقدار‌دهی متغیرهای مورد نیاز
            const int port = 12345; // پورت UDP
            const string ipAddress = "127.0.0.1";
            var udpServer = new System.Net.Sockets.UdpClient(port);
            var clientEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            try
            {
                Console.WriteLine("The UDP server is listening for connections...");

                while (true)
                {
                    // دریافت داده از کلاینت
                    byte[] data = udpServer.Receive(ref clientEndPoint);
                    string receivedMessage = Encoding.UTF8.GetString(data);

                    Console.WriteLine($"پیام دریافتی: {receivedMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                udpServer.Close();
            }
        }
    }
}
