    public static bool WaitForFileLock(string path, int timeInSeconds)
    {
      bool fileReady = false;
      int num = 0;
    
      while (!fileReady)
      {
        if (!File.Exists(path))
        {
          return false;
        }
    
        try
        {
          using (File.OpenRead(path))
          {
            fileReady = true;
          }
        }
        catch (Exception)
        {          
          num++;
          if (num >= timeInSeconds)
          {
            fileReady = false;
          }
          else
          {
            Thread.Sleep(1000);
          }
        }
      }
    
      return fileReady;
    }
