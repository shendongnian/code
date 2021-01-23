    Expression<Func<Car,bool>> InitialSelection()
    {
        return x => x.make == "Ford";
    }
    
    public int GetDoorHandleCounts()
    {
        using(DbContext db = new DbContext())
        {
            return db.Cars()
                   .Where(InitialSelection())
                   .Where(x => x.partType == "DoorHandle").Count();
        }
    }
