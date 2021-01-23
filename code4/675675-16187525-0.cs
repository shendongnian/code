    var sessionFactory1 = new Configuration()
                        .Configure()
                        .SetProperty("connection.connection_string", "First Connection String").BuildSessionFactory();
    
    var sessionFactory2 = new Configuration()
                        .Configure()
                        .SetProperty("connection.connection_string", "Second Connection String").BuildSessionFactory();
