    int[] array = { 1, 2, 3, 44, 55, 66, 44, 1 };
    
                var x = array.GroupBy(t => t).Where(g => g.Key > 10).Select(g=>
                                                                              new {
                                                                                  Number = g.Key,
                                                                                  Count = g.Count()
                                                                                });
    
              foreach (var n in x)
              {
                  Console.WriteLine("Number{0}\nCounts:{1}", n.Number, n.Count);
              }
