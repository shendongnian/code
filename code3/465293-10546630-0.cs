     string pattern = "##";
     string sentence = "45##78$$#56$$J##K01UU";
     IList<int> indeces = new List<int>();
     foreach (Match match in Regex.Matches(sentence, pattern))
     {
          indeces.Add(match.Index);
     }
