    //For counting unique words
     private int UniqueWordCount(string fbStatus)
            {
                int count = 0;
                var countedWordList = new List<string>(100);
                var reg = new Regex(@"\w+");
                foreach (Match match in reg.Matches(fbStatus))
                {
                    string word = match.Value.ToLower();
                    if (!countedWordList.Contains(word))
                    {
                        ++count;
                        countedWordList.Add(word);
                    }
                }
                label_totaluniquewords.Text = count.ToString();
                return count;
            }
  
    private int SplitWords(string fbStatus)
            {
                int splitWords = fbStatus.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Count();
                label_totalwordcount.Text = splitWords.ToString();
                return splitWords;
            }
    //For counting lexical density (trying to make this work...)
       private void CalculateLexicalDensity(string fbStatus)
            {
                int ld = 0;
                ld = ((decimal)UniqueWordCount(fbStatus) / (decimal)SplitWords(fbStatus)) * 100;
                label_lexicaldensity.Text = ld.ToString();
            }
