    var collection = new ListCollectionView(new List<Test>());            
    collection.AddNewItem(new Test() { Name = "Bob", IsTrue = false });
    collection.CommitNew();
    
    collection.SortDescriptions.Add(new SortDescription("IsTrue", 
                                              ListSortDirection.Ascending));   
    collection.GroupDescriptions.Add(new PropertyGroupDescription("Name"));
