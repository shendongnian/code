      List<int> ints = new List<int>();
      ints.Add(1);
      ints.Add(2);
      ints.Add(3);
      ints.Add(4);
      for (int i = 0; i < ints.Count; i += 2)
      {
        var pair = ints.Skip(i).Take(2);
        var first = pair.First();
        var last = pair.Last();
      }
