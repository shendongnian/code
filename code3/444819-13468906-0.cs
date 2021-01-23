    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
    }
    
    protected override void Seed(HallContext context)
    {
        context.Halls.AddOrUpdate(
            h => h.Id,
            new Hall
            {
                Id = 1,
                Name = "Hall 1"
            },
            new Hall
            {
                Id = 2,
                Name = "Hall 2"
            });
    
        context.SaveChanges();
    }
