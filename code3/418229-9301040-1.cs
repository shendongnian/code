    public interface ICustomerRepositoryFactory
    {
      ICustomerRepository Create(string connectionString);
    }
    
    container.RegisterType<ICustomerRepositoryFactory>(new TypedFactory());
    container.RegisterType<ICustomerRepository, CustomerRepository>(new InjectionProperty("ConnectionString");
