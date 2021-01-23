    var TheData = MyDC.Table
                      .Where(...)                      
                      .ToList() // move execution to memory
                      .Select(l => new Model() {
                          TheListOfLongs = l.StringOfLongs.Split(',')
                                            .Select(x => Int64.Parse(x))
                                            .ToList(),
                          SomeObjectProp = l.SomeObjectProp
                      }).ToList();
