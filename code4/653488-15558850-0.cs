    ItemView view = new ItemView(int.MaxValue);
    FindItemsResults<Item> findResults;
    view.PropertySet = itempropertyset;
    SearchFilter searchFilter = 
       new SearchFilter.IsGreaterThan(ItemSchema.DateTimeReceived, DateTime.Now.AddDays(-3));
    findResults = service.FindItems(WellKnownFolderName.Inbox, searchFilter, view);
