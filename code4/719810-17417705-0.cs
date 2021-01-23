    public class Program
    {
        static void Main(string[] args)
        {
            AsyncSocketTest test = new AsyncSocketTest();
            test.SocketTest();
        }
    }
    public class AsyncSocketTest
    {
        private Socket socket;
        private byte[] buffer;
        private volatile bool keepRunning;
        public void SocketTest()
        {
            Console.Out.WriteLine("Starting connect...");
            Console.Out.Flush();
            buffer = new byte[65536];
            keepRunning = true;
            // connect to antiduh.com's web server
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.BeginConnect(IPAddress.Parse("129.21.49.41"), 80, new AsyncCallback(OnConnect), null);
            // Keep the main thread alive while all of the async requests run.
            while (keepRunning) { Thread.Sleep(500); }
            Console.Out.WriteLine("Quitting.");
            Console.Out.Flush();
        }
        private void OnConnect(IAsyncResult result)
        {
            try
            {
                if (result.IsCompleted == false)
                {
                    Console.Out.WriteLine("OnConnect got incomplete result: " + result);
                }
                else
                {
                    socket.EndConnect(result);
                    if (result.IsCompleted == false)
                    {
                        Console.Out.WriteLine("OnConnect got incomplete result: " + result);
                    }
                    else
                    {
                        Console.Out.WriteLine("Sending...");
                        byte[] requestBytes;
                        string requestString =
                            "GET / HTTP/1.1\n" +
                            "Host: antiduh.com\n" +
                            "\n";
                        requestBytes = Encoding.ASCII.GetBytes(requestString);
                        socket.Send(requestBytes);
                        Console.Out.WriteLine("Starting receive...");
                        socket.BeginReceive(
                            buffer, 
                            0, 
                            buffer.Length, 
                            SocketFlags.None, 
                            new AsyncCallback(OnReceive),
                            null
                        );
                    }
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Caught exception in OnConnect: " + e);
            }
            finally
            {
                Console.Out.Flush();
            }
        }
        private void OnReceive(IAsyncResult result)
        {
            int received = socket.EndReceive(result);
            string responseStr;
            Console.Out.WriteLine("Received data: Length: {0}. Data: \r\n\r\n", received);
            Console.Out.Flush();
            responseStr = Encoding.ASCII.GetString(buffer, 0, received);
            Console.Out.WriteLine(responseStr);
            Console.Out.Flush();
            socket.Close();
            keepRunning = false;
        }
    }
