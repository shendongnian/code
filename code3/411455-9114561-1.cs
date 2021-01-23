    using System;
    using System.IO;
    using System.IO.Pipes;
    
    class NamedPipeExample
    {
    
      private void client() {
        NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", 
          "testpipe", PipeDirection.InOut, PipeOptions.None);
        if (pipeClient.IsConnected != true) { pipeClient.Connect(); }
        StreamReader sr = new StreamReader(pipeClient);
        StreamWriter sw = new StreamWriter(pipeClient);
        string temp;
        temp = sr.ReadLine();
        if (temp == "Waiting") {
          try {
            sw.WriteLine("Test Message");
            sw.Flush();
            pipeClient.Close();
          }
          catch (Exception ex) { throw ex; }
        }
      }
    
      private void server() {
        NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut, 4);
        StreamReader sr = new StreamReader(pipeServer);
        StreamWriter sw = new StreamWriter(pipeServer);
        do {
          try {
            pipeServer.WaitForConnection();
            string test;
            sw.WriteLine("Waiting");
            sw.Flush();
            pipeServer.WaitForPipeDrain();
            test = sr.ReadLine();
            Console.WriteLine(test);
          }
          catch (Exception ex) { throw ex; }
          finally {
            pipeServer.WaitForPipeDrain();
            if (pipeServer.IsConnected) { pipeServer.Disconnect(); }
          }
        } while (true);
      }
    }
    
