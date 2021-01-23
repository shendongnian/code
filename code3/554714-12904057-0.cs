    var TheQuery =  from t in MyDC.Table
                    where....
                    select new MyModel()
                    {
                        Property1 = (int?)... ?? 0
                    }
    
    var after = TheQuery.Any() ? 
                TheQuery : 
                Enumerable.Range(0, 1).Select(k => new MyModel() { Property1 = 0 });
