    private IQueryOver GetFilteredQuery()
    {
        var query = Session.QueryOver<Car>();
    
        if (this.Colour != null)
        {
            query.Where(x => x.Colour == this.Colour));
        }
    
        if (this.GetOldestCar)
        {
            query.OrderBy(x=>x.Age).Desc().Take(1)
        }
    
        return query;
    }
