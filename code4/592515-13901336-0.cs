            var ab = A.Concat(B).GroupBy(x => new
                                                  {
                                                          x.ObjectId1,
                                                          x.ObjectId2
                                                  });
            var result = ab.Select(x => new SomeClass
                                            {
                                                    ObjectId1 = x.Key.ObjectId1,
                                                    ObjectId2 = x.Key.ObjectId2,
                                                    ActiveFilterThickness = x.Sum(i => i.ActiveFilterThickness),
                                                    ActiveThickeness = x.Sum(i => i.ActiveThickeness)
                                            });
