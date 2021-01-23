        using (var db = new MyContext())
        {
            var results = db.MyEntity.FirstOrDefault();
        }
     
