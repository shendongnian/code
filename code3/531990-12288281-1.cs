    var pairCounts = pairList
                        .GroupBy(p=>p, //key selector; we want the Tuple itself
                           new GenericEqualityComparer<Tuple<string,string>>(
                              (a,b)=>(a.Item1 == b.Item1 && a.Item2 == b.Item2) 
                                 || (a.Item1 == b.Item2 && a.Item2 == b.Item1))
                        .Select(g=>new Tuple<string, int>(g.Key.Item1 + " - " + g.Key.Item2,
                                                          g.Count());
