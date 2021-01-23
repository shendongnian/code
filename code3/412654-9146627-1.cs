    using (myEntities = new RamRideOpsEntities())
    {
          var validDates = (from a in myEntities.AdminOptions
                            select new { a.ValidDate1, a.ValidDate2 }).FirstOrDefault();
    
          if (validDates != null)
          {
             RidesEDS.Where = @"it.TimeOfCall >= @ValidDate1 AND it.TimeOfCall <= @ValidDate2";
             RidesEDS.WhereParameters.Add(@"ValidDate1", DbType.DateTime, validDates.ValidDate1.ToString());
             RidesEDS.WhereParameters.Add(@"ValidDate2", DbType.DateTime, validDates.ValidDate2.ToString());
          }
     }
