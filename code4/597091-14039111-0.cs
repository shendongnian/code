     // A static method in Customer class.
     public static Customer Get(string key)
     {
         Customer customer;
         FCustomers.TryGetValue(key, out customer);
         return customer;
     }
