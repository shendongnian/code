    StreamWriter file2 = new System.IO.StreamWriter(myFilePath);
    try
    {
       newFileContents.ForEach(file2.WriteLine);
    }
    finally
    {
       if (file2!= null)
           ((IDisposable)file2).Dispose();
    }
