    using (var db = new CreateDbContext())
    {
        if(!db.Projects.Any())
        {
            // The table is empty
        }
    }
