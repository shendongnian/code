    Tuple<List<A>, List<B>> Unpack<A, B>(List<Tuple<A, B>> list)
    {
        return list.Aggregate(Tuple.Create(new List<A>(list.Count), new List<B>(list.Count)),
                              (unpacked, tuple) =>
                              {
                                  unpacked.Item1.Add(tuple.Item1);
                                  unpacked.Item2.Add(tuple.Item2);
                                  return unpacked;
                              });
    }
