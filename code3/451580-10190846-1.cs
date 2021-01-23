    u = new User();
    using (var dc = new DataContext())
    {
        u.Name = "Second";
        u.Country = countries[0];
        dc.Users.Attach(u);
        dc.Entry(u).State = System.Data.EntityState.Added;
        dc.SaveChanges();
    }
    using (var dc = new DataContext())
    {
        u.Name = "SecondChanged";
        u.Country = countries[1];
        dc.Users.Attach(u);
        ObjectContext oc = ((IObjectContextAdapter)dc).ObjectContext;
        oc.ObjectStateManager.ChangeObjectState(u, EntityState.Modified);
        oc.ObjectStateManager.ChangeRelationshipState(u, countries[1], x => x.Country, EntityState.Added);
        dc.SaveChanges();
    }
