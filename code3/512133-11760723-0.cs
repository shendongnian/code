    var flattenedListOfPairs = listOfPairs.Select(pair => 
                                                      {
                                                          var list = new List<int>(pair.First);
                                                          list.AddRange(pair.Second));
                                                          return list;
                                                      }.ToList();
