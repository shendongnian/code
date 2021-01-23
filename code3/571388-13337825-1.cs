    public IList<foods> GetFoods()
    {
        using (var db = new FoodsContext(ConnectionString))
        {
            return db.Employees.Select(e => new foods 
                                             { 
                                               calorie = e.calorie,
                                       
                                               // Map other properties of foods object here
                                             }).ToList<foods>();
        }
    }
