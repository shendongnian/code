    using (ISession session = sessionFactory.OpenSession())
    {
        var query = from customer in session.Query<Customer>()
                    select customer;
    
        var c = query.Take(1).SingleOrDefault<Customer>();
    }
