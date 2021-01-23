    NamedPipeClientStream pipe = null;
    try 
    {
      pipe = new NamedPipeClientStream(THIS_SERVER, this.Name, PipeDirection.InOut, PipeOptions.None);
      using (StreamReader sr = new StreamReader(pipe))
      {
        string message = sr.ReadLine();
        using (StreamWriter sw = new StreamWriter(pipe))
        {
            sw.WriteLine("ACK received"); 
        }
      }
      pipe = null;
    } 
    finally 
    {
      if (pipe != null)
      {
        pipe.Dispose();
      }
    }
    
