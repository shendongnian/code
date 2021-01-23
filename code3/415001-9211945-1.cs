    using (var context = new DetailsContext())
    {
       DetailsEntity _detail = new DetailsEntity();       // EF table object
    
       foreach (datamemeber in Details)
       {
          _detail.FieldLabel = datamemeber.Type;
          _detail.FieldValue = datamember.Value;
       }
    
       context.SaveChanges();
    }
