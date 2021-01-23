    [Invoke]
    public IQueryable<POINT> UpdateDB()
    {
      var Points =  ObjectContext.POINTS.Include("Readings").Include("Items").Include("LatestStatus");
      var itemsChanged = new List<POINT>();
    
      foreach (Point point in Points)
      {
        int status = CalculateStatus(point);
        if (point.LatestStatus.FirstOrDefault().Status != status) // Where does this status come from?
        {
          ObjectContext.POINTS.FirstOrDefault( p => p.ID == point.ID).LatestStatus.FirstOrDefault().Status = new status //  Pseudo code?
          //point.LatestStatus.FirstOrDefault().Status = new status
        }
      }
    
      ObjectContext.SaveChanges();
    }
