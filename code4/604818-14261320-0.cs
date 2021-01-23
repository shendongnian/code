    int i = 0;
    int index;
    foreach(string s in src)
    {
      index = i % lists.Length; //lists is the List<List<string>>
      lists[index].Add(s);
      i++;
    }
