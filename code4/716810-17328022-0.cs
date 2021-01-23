    // First build an in memory list of objects to add.
    var listsToAdd = new List<List_Visitor>();
    foreach (string item in sc)
    {
      if (item.Contains(","))
      {
        var splitItems = item.Split(",".ToCharArray());
        listsToAdd.Add(new List_Visitor()
        {
          Fullname = splitItems[0],
          add = splitItems[1]
        });
      }
    }
    
    // Then add all to the db in one call. Wrap in using block to
    // propery dispose of the DataContext and underlying connection.
    using(var db = new Travel_DBDataContext())
    {
      db.List_Visitors.InsertAllOnSubmit(listsToAdd);
      db.SubmitChanges();
    }
    
    // At this point listsToAdd contains all added lists with the generated
    // primary key.
    
