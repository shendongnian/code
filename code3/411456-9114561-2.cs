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
    
