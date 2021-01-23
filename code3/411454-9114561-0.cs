    using System;
    using System.IO;
    
    class NamedPipeExample
    {
    
        private void client()
        {
            System.IO.Pipes.NamedPipeClientStream pipeClient = new System.IO.Pipes.NamedPipeClientStream(".", "testpipe", System.IO.Pipes.PipeDirection.InOut, System.IO.Pipes.PipeOptions.None);
            
            if (pipeClient.IsConnected != true) { pipeClient.Connect(); }
    
            StreamReader sr = new StreamReader(pipeClient);
            StreamWriter sw = new StreamWriter(pipeClient);
            
            string temp;
            temp = sr.ReadLine();
    
            if (temp == "Waiting")
            {
                try
                {
                    sw.WriteLine("Test Message");
                    sw.Flush();
                    pipeClient.Close();
                }
                catch (Exception ex) { throw ex; }
            }
        }
    
        private void server()
        {
            System.IO.Pipes.NamedPipeServerStream pipeServer = new System.IO.Pipes.NamedPipeServerStream("testpipe", System.IO.Pipes.PipeDirection.InOut, 4);
    
            StreamReader sr = new StreamReader(pipeServer);
            StreamWriter sw = new StreamWriter(pipeServer);
    
            do
            {
                try
                {
                    pipeServer.WaitForConnection();
                    string test;
                    sw.WriteLine("Waiting");
                    sw.Flush();
                    pipeServer.WaitForPipeDrain();
                    test = sr.ReadLine();
                    Console.WriteLine(test);
                }
    
                catch (Exception ex)
                { throw ex; }
    
                finally
                {
                    pipeServer.WaitForPipeDrain();
                    if (pipeServer.IsConnected) { pipeServer.Disconnect(); }
                }
            } while (true);
        }
    }
    
