      Match m = Regex.Match(source, jointPattern);
      if (m.Success)
      {
        foreach (Capture c in m.Groups[1].Captures)
        {
          Console.WriteLine(c.Value);
        }
      }
