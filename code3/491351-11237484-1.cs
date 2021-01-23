    using System;
    using System.IO;
    using System.Net.Sockets;
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new TcpClient("localhost", 1100);
                var stream = client.GetStream();
                var streamWriter = new StreamWriter(stream);
                streamWriter.WriteLine("My name is Theo");
                streamWriter.Flush();
                var streamReader = new StreamReader(stream);
                Console.WriteLine("Received: " + streamReader.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
    
            Console.WriteLine("Press a key to continue.");
            Console.ReadKey();
        }
    }
