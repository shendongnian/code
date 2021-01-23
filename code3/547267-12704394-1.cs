      Dictionary<string, byte> dict = new Dictionary<string, byte>();
      foreach (string s in a)
      {
          dict.Add(s, 0);
      }
      bool same = true;
      foreach (string s in b)
      {
          same &= dict.ContainsKey(s);
          if (!same) 
              break;
      }
