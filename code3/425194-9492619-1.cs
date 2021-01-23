    var oneList = new List<ObjectOne>
                  {
                    new ObjectOne {Name = "Name One", Item = "Item One"},
                    new ObjectOne {Name = "Name One", Item = "Item Two"},
                    new ObjectOne {Name = "Name Two", Item = "Item Three"}
                  };
    var twoList= oneList.GroupBy(one => one.Name)
                        .Select(one => new ObjectTwo 
                                       {
                                          Name = one.Key, 
                                          Items = one.Select(t => t.Item)
                                       });
