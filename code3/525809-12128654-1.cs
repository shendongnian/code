    public IQueryable<Car> GetInitialQuery(DbContext db)
    {
        return db.Cars().Join(....)
               .Where(x => x.make == "Ford")
               .Where(....);
    }
    
    public int GetDoorHandleCounts()
    {
        using(DbContext db = new DbContext())
        {
            return GetInitialQuery(db)
                   .Where(x => x.partType == "DoorHandle").Count();
        }
    }
