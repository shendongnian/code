    List<String> SortItems = list.Select(s => new
                                  {
                                      Item = s, 
                                      Number = int.Parse(s.Substring("Item".Length))
                                  }).OrderBy(x => x.Number)
                                  .Select(x => x.Item).ToList();
