    protected override void Seed(EFDbContext context)
    {
        context.Admins.Add(new Admins
        {                
            Username = "admin",
            Password = "admin123456",
        });
        base.Seed(context);
        context.SaveChanges();
    }
