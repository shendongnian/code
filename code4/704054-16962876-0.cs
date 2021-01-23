    var entity = entry.Entity as IContainAuditProperties;
    if(entity != null)
    {
      entity.CreatedDate = DateTime.Now;
      entity.ModifiedDate = DateTime.Now;
      //etc.
    }
