    string regexPattern;
    foreach (KeyWord key in cKeyWords)
    {
      foreach (string word in userWords)
      {
        regexPattern = string.Format(@"\b{0}\b", System.Text.RegularExpressions.Regex.Escape(word));
        if (System.Text.RegularExpressions.Regex.IsMatch(key.keyWord, regexPattern))
        {
            ckeyList.Add(key);
        }
      }
    }
