    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new FunctionsConvention<MyContext>("dbo"));
        }
     
        [DbFunction("MyContext", "CustomersByZipCode")]
        public IQueryable<Customer> CustomersByZipCode(string zipCode)
        {
            var zipCodeParameter = zipCode != null ?
                new ObjectParameter("ZipCode", zipCode) :
                new ObjectParameter("ZipCode", typeof(string));
     
            return ((IObjectContextAdapter)this).ObjectContext
                .CreateQuery<Customer>(
                    string.Format("[{0}].{1}", GetType().Name, 
                        "[CustomersByZipCode](@ZipCode)"), zipCodeParameter);
        }
     
        public ObjectResult<Customer> GetCustomersByName(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
     
            return ((IObjectContextAdapter)this).ObjectContext.
                ExecuteFunction("GetCustomersByName", nameParameter);
        }
    }
