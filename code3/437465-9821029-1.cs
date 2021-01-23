    using (var context = new YourObjectContext())
    {
        context.SamepleModels.Attach(sampleModel);
        ObjectStateEntry entry = context.ObjectStateManager.GetObjectStateEntry(sampleModel);
        entry.SetModifiedProperty("Name");
        entry.SetModifiedProperty("Age");
        entry.SetModifiedProperty("Address"); 
      
        context.SaveChanges();
    }
