    using (var ts = new TransactionScope())
    {
        var db = new Db();
        var asd = from x in db.MyTable
                    where x.Id == 1
                    select x;
        db.SaveChanges(); // you still can fire selects in the studio
        asd.First().Name = "test2"; // now a change is made but not written to the transaction
        db.SaveChanges(); // after this call you can't fire selects in the management studio, the table is locked
        var asd2 = from x in db.MyTable
                    where x.Id == 1
                    select x;
        asd2.First().Name = "test3";
        db.SaveChanges(); // the table still is locked
    }
    // now you can do selects again, the table is unlocked
