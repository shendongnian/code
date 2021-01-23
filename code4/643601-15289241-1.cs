    var anotherlist = list1.GroupBy(g => g.Name)
                      .Select(s => new
                      {
                          Name = s.Key,
                          DocCount = s.Sum(i => i.DocCount)
                      });
