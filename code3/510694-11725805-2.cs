    List<string> words = new List<string>();
    int indexLast, count;//hold index of last word discovered & count
    for (int x= 0; x <= testStr.Length; x++)
    {
       string test = testStr.Substring(indexLast + x);
       if (test.Length > 0 && list.Contains(test))
       {
          count++;//increase the number of words discovered
          words.Add(test);
          indexLast = x;//substring from this index on next loop
       }
    }
