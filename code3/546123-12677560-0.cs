    using (MyDataContext db = new MyDataContext()) {
                    
        var results = (from m in db.MyTable
                       where m.UserId == userId
                       select m);
    
        // Loop over all of the rows returned by the previous query and do something with it
        foreach (var m in results) {
            // m represents a single row in the results, do something with it.
            Console.WriteLine(m.UserId);
        }
    
    }
