    void incrementCount(Dictionary<string, int> counts, string word)
    {
      if (counts.Contains(word))
      {
        counts[word]++;
      }
      else
      {
        counts.Add(word, 0);
      }
    }
    var stemmedCount = new Dictionary<string, int>();
    var nonStemmedCount = new Dictionary<string, int>();
    
    foreach(word in words)
    {
      incrementCount(stemmedCount, Stem(word));
      incrementCount(nonStemmedCount, word);
    }
