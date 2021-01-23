    using (var context = new DbContext())
      {
         var svc100 = context.SVC00100
                     .FirstOrDefault(t => t.TECHEMAIL.Contains(model.UserName));
    
         // Read the current value of the Name property
         if (svc100 != null && !String.IsNullOrEmpty(svc100.Name))
             Session["Name"] = svc100.Name;
      }
