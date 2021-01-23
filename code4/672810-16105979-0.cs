    using (StreamReader streamReader = new StreamReader(this.MyPath))
    {
     var regEx = new RegEx(MyPattern, RegexOptions.Compiled);
     while (streamReader.Peek() > 0)
     {
          string line = streamReader.ReadLine();
          if (regEx.IsMatch(line))
          {
               // Do some action with the string.
          }
     }
    }
