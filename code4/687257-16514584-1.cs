    StreamWriter c =null;
    try
    {
      c = new StreamWriter(fileFullPath, true);
      c.WriteLine("hello");
    }
    finally
    {
      if (c!= null)
          c.Close();
    }
