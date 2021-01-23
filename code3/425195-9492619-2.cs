    var oneList = new List<ObjectOne>
                  {
                    new ObjectOne {Name = "Name One", Item = "Item One"},
                    new ObjectOne {Name = "Name One", Item = "Item Two"},
                    new ObjectOne {Name = "Name Two", Item = "Item Three"}
                  };
    var twoList= oneList.GroupBy(x => x.Name)
                        .Select (x => new ObjectTwo 
                                       {
                                          Name = x.Key, 
                                          Items = x.Select(t => t.Item)
                                       });
