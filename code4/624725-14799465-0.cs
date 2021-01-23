    Project proj;
    using (var db = new MyDbContext())
    {
        // Fetch a detached project and populate its BusinessRequirements.
        proj = db.Projects.AsNoTracking().Include(p => p.BusinessRequirements)
                 .First(p => p.Id == source.Id);
        db.Projects.Add(proj);
        db.SaveChanges();
    }
