    protected override void Seed(HallContext context)
    {
        context.Halls.AddOrUpdate(
            h => h.Name,   // Use Name (or some other unique field) instead of Id
            new Hall
            {
                Name = "Hall 1"
            },
            new Hall
            {
                Name = "Hall 2"
            });
    
        context.SaveChanges();
    }
