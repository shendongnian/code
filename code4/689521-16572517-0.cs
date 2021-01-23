       var results = (from z in mContext.View
                                     orderby z.ItemNumber ascending
                                     where z.ItemId == mId
                                     select new Items()
                                     {                                         
                                         Id = z.ItemId,
                                         Details = z.Details,
                                         Title = z.ItemTitle,
                                         NewNumber = z.ItemNumber
    
                                     }).DistinctBy(c=>c.Title).ToList();
