    var alert = new Alert();
    
    ...
    
    using (var context = new MyContext())
    {
    
      // Replace temp check with actual database check if available.
      var checkFromDb = context.Checks.SingleOrDefault(
          c => c.UniqueProperty = alert.Check.UniqueProperty);
      if (checkFromDb != null)
      {
        checkFromDb.Alerts.Add( alert );
      }
      else
      {
        alert.Check = new Check { UniqueProperty = some value };
        context.Alerts.AddObject(alert);
      }
      context.SaveChanges();
    }
