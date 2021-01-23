    public static Customer Map(CustomerEntity entity)
    {
         return new Customer
         {
              CustomerId = entity.CustomerId,
              Company = entity.CompanyName,
              City = entity.City,
              Country = entity.Country
         };
    }
