      string s = "111";
      int i;
      if (int.TryParse(s, out i))
      {
         Console.Write(i);
      }
      else
      {
          Console.Write("conversion failed");
      }
