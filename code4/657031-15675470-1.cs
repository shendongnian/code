    using ZMQ;
    namespace TestConsole 
    {
        class Program
        {
            static void Main(string[] args)
            {
                // ZMQ Context and client socket
                using (Context context = new Context())
                using (Socket client = context.Socket(SocketType.PUSH))
                {
                    client.Connect("tcp://127.0.0.1:2202");
                    string request = "Hello";
                    for (int requestNum = 0; requestNum < 10; requestNum++)
                    {
                        Console.WriteLine("Sending request {0}...", requestNum);
                        client.Send(request, Encoding.Unicode);
    
                        string reply = client.Recv(Encoding.Unicode);
                        Console.WriteLine("Received reply {0}: {1}", requestNum, reply);
                    }
                }
            }
        }
    }
