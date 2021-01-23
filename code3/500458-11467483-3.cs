    StreamWriter sr = new StreamWriter(streamFolder);
    try 
    {
       sr.Write(details);
       // some exception occurs here 
       File.SetAttributes(streamFolder, FileAttributes.Hidden);
    }
    finally
    {
       if (sr != null)
          sr.Dispose();
    }
