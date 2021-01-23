    using (var db = new DataClasses1DataContext())
    {
        var result = db.MyTable.SingleOrDefault(myTable => myTable.SomeCondition);
        // Use result...
    }
