    {
       ...
       int handleCounts = getDoorHandleCounts("Ford");
    }
    
    public int getDoorHandleCounts(string Make)
    {
         using(DbContext db = new DbContext())
         {
              return db.cars.where(x => x.make == Make && x.partType == "DoorHandle").Count();
         }
     }
    
