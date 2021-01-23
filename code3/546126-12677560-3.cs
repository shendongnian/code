    using (MyDataContext db = new MyDataContext()) {
    
        var singleResult = (from m in db.MyTable
                            where m.UserId == userId
                            select m).SingleOrDefault();
        
        // Do something with the single result
        if (singleResult != null) {
            Console.WriteLine(singleResult.UserId);
        }
    
    }
