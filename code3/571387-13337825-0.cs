    public IList<foods> GetFoods()
    {
        IList<foods> myFoods = null;
        using (var db = new FoodsContext(ConnectionString))
        {
            var query = from e in db.MyFoods
                        select new foods 
                        {
                            calorie = e.calorie,
                            // Map other properties of foods object here
                        };
            myFoods = query.ToList();
            return myFoods;
        }
    }
