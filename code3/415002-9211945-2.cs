    Details details = Populate();  // Populated from parameter passed in
    using (var context = new DetailsContext())
    {
       DetailsEntity _detail = new DetailsEntity();       // EF table object
    
       foreach (datamemeber in details)
       {
          _detail.FieldLabel = datamemeber.Type;
          _detail.FieldValue = datamember.Value;
       }
    
       context.SaveChanges();
    }
