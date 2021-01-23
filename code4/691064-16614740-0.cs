      try
      {
        using (StreamWriter sw = new StreamWriter("my.txt", true))
        {
          sw.WriteLine(dir.Name);
        }
      }
      catch
      {
          //maybe retry in 5 seconds
      }
