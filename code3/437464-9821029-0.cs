    using (var context = new YourDbContext())
    {
        context.SamepleModels.Attach(sampleModel);
        DbEntityEntry<SameplModel> entry = context.Entry(sampleModel);
        entry.Property(e => e.Name).IsModified = true;
        entry.Property(e => e.Age).IsModified = true;
        entry.Property(e => e.Address).IsModified = true;   
      
        context.SaveChanges();
    }
