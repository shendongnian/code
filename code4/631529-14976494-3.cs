      var output = new StringBuilder();
      foreach (Char c in input)
      {
        for (int i = 0; i < alphabet.Length; i++)
        {
          if (c == alphabet[i])
          {
            if (Char.IsUpper(c))
              output.AppendFormat("C{0} ", i-26); 
            else
              output.AppendFormat("{0} ",i);
          }
        }
      }
      return output.ToString();
