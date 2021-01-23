      string s = "Test spaces in a sentence :)";
      int numSpaces = 1;
      foreach (char c in s)
      {
        if (c == ' ')
        {
          ++numSpaces;
        }
      }
      string[] output = new string[numSpaces];
      int spaceIndex = s.IndexOf(' ');
      int index = 0;
      int startIndex = 0;
      --numSpaces;
      while (index < numSpaces)
      {
        output[index] = s.Substring(startIndex, spaceIndex - startIndex);
        startIndex = spaceIndex + 1;
        spaceIndex = s.IndexOf(' ', startIndex);
        ++index;
      }
      output[index] = s.Substring(startIndex);
      foreach (string str in output)
      {
        Console.WriteLine(str);
      }
