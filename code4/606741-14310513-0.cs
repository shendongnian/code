    List<FullList> x = (from l in entities.Lists
                       select l) // create your query
                       .ToList() // execute query and get the List<Entity>
                       .Select(l => new FullList // customize your result (convert to List<FullList>)
                                    {
                                      ListID = l.ListID,
                                      ListName = l.ListName,
                                      ListItems = l.ListItems.Select(li => new ListItems
                                           {
                                               ItemID = li.ItemID,
                                               ItemName = li.ItemName
                                           }).ToList()
                                    }).ToList();
