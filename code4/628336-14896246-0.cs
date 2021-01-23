      var pairs = numbers.Select(x =>
                                      {
                                        List<KeyValuePair<int, IList<int>>> pairList = new List<KeyValuePair<int, IList<int>>>();
                                        for (int i = 0; i <= 4; i++)
                                        {
                                          for (int j = i + 1; j <= 5; j++)
                                          {
                                            //Get the pair
                                            var pair = new List<int> { x.Skip(i).First(), x.Skip(j).First() };
                                            //Pair should be unique, so make the ID the sum
                                            pairList.Add(new KeyValuePair<int, IList<int>>(pair.Sum(), pair));
                                          }
                                        }
                                        return pairList;
                                      }).SelectMany(x => x.Select(y => y.Value)).GroupBy(x => x, new PairComparer()).ToList();
      int iHighest = pairs.Max(p => p.Count());
      var highestPairs = pairs.Where(pair => pair.Count() == iHighest);
