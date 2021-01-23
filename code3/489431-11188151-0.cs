    // ...
    while (i < Matches.Count)
    {
         String str = Matches[i].ToString();
         if (!(str.StartsWith("<") && str.EndsWith(">"))) {
             ...
         }
         i++;
    }
