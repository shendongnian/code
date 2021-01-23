    Dictionary<string, int> m_WordIndexes = new Dictionary<string, int>();
    int GetWordIndex(string word)
    {
      int result;
      if (!m_WordIndexes.TryGet(word, out result)) {
        result = m_WordIndexes.Count;
        m_WordIndexes.Add(word, result);
      }
      return result;
    }
