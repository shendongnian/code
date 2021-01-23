      try
      {
          ...
      }
      catch (Exception e)
      {
          foreach(String s in StringExtension.Wrap(e.Message, Console.Out.BufferWidth))
          {
              Console.WriteLine(s);
          }
      }
