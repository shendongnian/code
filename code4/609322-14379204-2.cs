    public static class RepositoryRegistry
    {
        internal static void DefaultConfiguration(Registry registry)
        {
           registry.For<ICustomerRepository>().Use<CustomerRepository>();
        }
    }
