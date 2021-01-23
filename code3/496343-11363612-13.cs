    public IEnumerable<int> IndexesOf(string str, char c)
    {
      for(int position = 0; position < str.Length; position++)
      {
        char x = str[position];
        if (x == c)
        {
          yield return position;
        }
      }
    }
