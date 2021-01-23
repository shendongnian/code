    ObservableCollection<Data> listA = GetListA();
    ObservableCollection<Data> listB = GetListB();
    
    FullOuterJoiner<Data, Data, string> joiner =
      new FullOuterJoiner(listA, listB, a => a.Key, b => b.Key);
    
    foreach(Data a in joiner.LeftOnly)
    {
      listA.Remove(a);  // O(n), sigh
    }
    foreach(Data b in joiner.RightOnly)
    {
      listA.Add(b);
    }
    foreach(Tuple<Data, Data> tup in joiner.Matched)
    {
      tup.Item1.Value = tup.Item2.Value;
    }
