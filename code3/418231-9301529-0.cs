    container.Configure<IStaticFactoryConfiguration>()
        .RegisterFactory<ICustomerRepository>
        (new FactoryDelegate(c => 
           { 
              var repos = new CustomerRepository();
              repos.ConnectionString = yourComPlus.ConnectionString;
              return repos;
           }
        ));
