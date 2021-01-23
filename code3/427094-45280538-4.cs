    String  
    .Join
    (" ",     
      new string  
      (stringToRemoveWhiteSpaces
          .Select
          (
             c => char.IsWhiteSpace(c) ? ' ' : c
          )
          .ToArray<char>()
      )
      .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
      .Where(x => !string.IsNullOrEmpty(x.Trim()))
      .ToArray()
    )
