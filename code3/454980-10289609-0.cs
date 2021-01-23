    items = folder.FindItems(new ItemView(100)
					{
						Traversal = ItemTraversal.Shallow,
						PropertySet = PropertySet.IdOnly
					});
	service.LoadPropertiesForItems(items, new PropertySet(ItemSchema.DateTimeReceived, 
						ItemSchema.Subject));
