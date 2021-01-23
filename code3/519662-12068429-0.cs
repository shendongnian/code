    namespace EchoServer
    {
        public class PipeServer
        {
            public static void Main()
            {
                var pipeServer = new NamedPipeServerStream(@"Com.MyDomain.EchoServer.PipeServer", PipeDirection.In);
                pipeServer.WaitForConnection();
                StreamReader reader = new StreamReader(pipeServer);
                try
                {
                    int i = 0;
                    while (i >= 0)
                    {
                        i = reader.Read();
                        if (i >= 0)
                        {
                            Console.Write(Convert.ToChar(i));
                        }
                    }
                }
                catch (IOException)
                {
                    //error handling code here
                }
                finally
                {
                    pipeServer.Close();
                }
            }
        }
    } 
