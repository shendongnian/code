    using(DbContext db = new DbContext)
    {
       var carsResult = db.cars.where(x => x.make == "Ford");
    
       int handleCounts = getDoorHandleCounts(carsResult);
    }
    
    public int getDoorHandleCounts(IEnumerable<Car> result)
    {
         return result.where(x => x.partType == "DoorHandle").Count();         
    }
