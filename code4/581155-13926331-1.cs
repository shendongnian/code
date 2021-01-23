    protected override void Seed(icicle.Models.icicleEntities context)
    {
        //  This method will be called after migrating to the latest version.
    
        //   You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //   to avoid creating duplicate seed data. E.g.
                
        context.Widgets.AddOrUpdate(new Widget()
        {
             Id = 1,
             Name = "My Really Awesome Widget"
        });
    }
