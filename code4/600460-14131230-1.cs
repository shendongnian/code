    int? pageCount;
    using (Entities entities = new Entities())
    {
       pageCount = entities.GetAuditRecordPageCount(count).SingleOrDefault();
    
       if (pageCount.HasValue)
       {
          //do something here
       }
       else
       {
    
       }
    }
