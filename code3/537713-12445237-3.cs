     foreach (KeyWord key in cKeyWords)
    {
      foreach (string word in userWords)
      {
        regexPattern = string.Format(@"\b{0}\b", System.Text.RegularExpressions.Regex.Escape(word.ToLower()));
        if (System.Text.RegularExpressions.Regex.IsMatch(key.keyWord.ToLower(), regexPattern))
        {
            ckeyList.Add(key);
        }
      }
    }
 
