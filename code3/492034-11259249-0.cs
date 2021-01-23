    var test = new ShoppingItems()
                               {
                                    CustomerName = "test",
                                     Address = "testAddress",
                                      Items = new List<Item>()
                                                  {
                                                      new Item(){ Name = "item1", Price = "12"},
                                                      new Item(){Name = "item2",Price = "14"}
                                                  },
                               };
    
                var xmlData = Serialize(test);
