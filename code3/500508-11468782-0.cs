    using (MyEntities context = new MyEntities())
    {
        var myNewObject = new Table1()
        {
            StringColumn1 = "some value",
            StringColumn2 = "some value"
        });
    
        context.Table1.AddObject(myNewObject);
        context.SaveChanges();
        // get the new ID
        var newID = myNewObject.ID;
    }
