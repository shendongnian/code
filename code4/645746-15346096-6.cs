    container.RegisterInitializer<UserRepository>(rep => { 
        rep.ConnectionString = connectionString; });
    container.RegisterInitializer<OrderRepository>(rep => { 
        rep.ConnectionString = connectionString; });
    container.RegisterInitializer<CustomerRepository>(rep => { 
        rep.ConnectionString = connectionString; });
    container.RegisterInitializer<DocumentRepository>(rep => { 
        rep.ConnectionString = connectionString; });
