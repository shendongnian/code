    private IEnumerable<string> Traverse(string input)
    {
      int index = 0;
      string[] parts = input.Split(new[] {'/'});
      foreach(var part in parts)
      {
        index++;
        string retVal = string.Empty;
        switch(part)
        {
          case "{intIncG}":
            retVal = "a"; // or something based on index!
            break;
          case "{intIncD}":
            retVal = "b"; // or something based on index!
            break;
    
          ...
        }
        yield return retVal;
      }
    }
    
    string replaced = string.Join("/", Traverse(inputString));
