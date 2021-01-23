	List<Item> items = parsed.Select(pair => new Item 
                                                 {
                                                      Id = int.Parse(pair.Key),
                                                      Data = pair.Value
                                                 })
							 .ToList();
							 
	items.Dump();
