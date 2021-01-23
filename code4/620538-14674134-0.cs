    protected override void Seed(Context context)
        {
            var users = new List<UserProfile>
        {
             new UserProfile { UserId=1, UserName="Matt", Email="a@a.com", AccountType=AccountType.Tenant },
             new UserProfile { UserId=2, UserName="Dave", Email="a@a.com", AccountType=AccountType.Landlord }
        };
            users.ForEach(u => context.UserProfile.AddOrUpdate(u));
            context.SaveChanges();
    
            var tenants = new List<Tenant>
        {
            new Tenant { UserId = users.Single(x => x.UserId = context.UserProfile.First(x=>x.UserId = 1)) /* other properties */  }
            // ...
        };
            tenants.ForEach(t => context.Tenant.AddOrUpdate(t));
            context.SaveChanges();
    
            var landlords = new List<Landlord>
        {
            new Landlord { UserId = users.Single(x => x.UserId = context.UserProfile.First(x=>x.UserId = 2)) /* other properties */ }
            // ...
        };
            landlords.ForEach(l => context.Tenant.AddOrUpdate(l));
            context.SaveChanges();
        }
