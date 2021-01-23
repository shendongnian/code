    Tuple<List<A>, List<B>> Unpack<A, B>(List<Tuple<A, B>> list)
    {
      var listA = new List<A>(list.Count);
      var listB = new List<B>(list.Count);
      foreach (var t in list)
      {
        listA.Add(t.Item1);
        listB.Add(t.Item2);
      }
      
      return Tuple.Create(listA, listB);
    }
