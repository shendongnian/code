    List<string> words = str.Split(new char[]{'\r','\n'},
                                           StringSplitOptions.RemoveEmptyEntries).ToList();
    int[] indexes = words.Select((b, i) => b.StartsWith("Animal") ? i : -1).Where(i => i != -1).ToArray();
    List<string> temp = new List<string>();
    for (int i = 0; i < indexes.Length; i++)
    {
          if (i == indexes.Length - 1)
             temp.AddRange(words.GetRange(indexes[i] + 1, words.Count - (indexes[i] + 1)));
          else
             temp.AddRange(words.GetRange(indexes[i] + 1, indexes[i + 1] - (indexes[i] + 1)));
    }
    
    for (int y = 0; y < words.Count; y++)
    {
         if (temp.Contains(words[y]))
            words[y] = "\t" + words[y];
    }
