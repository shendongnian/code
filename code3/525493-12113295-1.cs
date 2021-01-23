    class LinqFlatten
    {
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            // need to flatten these lists
            public List<CreditCard> CreditCards { get; set; }
            public List<Address> Addresses { get; set; }
        }
        public class CreditCard
        {
            public string Name { get; set; }
        }
        public class Address
        {
            public string Street { get; set; }
        }
        public static void Test()
        {
            //  Customer has CreditCards list and Addresses list
            List<Customer> allCustomers = GetAllCustomers();
            // how to flatten Customer, CreditCards list, and Addresses list into one flattened record/list?
            var flatenned = from c in allCustomers
                            select
                                c.FirstName + ", " +
                                c.LastName + ", " +
                                String.Join(", ", c.CreditCards.Select(c2 => c2.Name).ToArray()) + ", " +
                                String.Join(", ", c.Addresses.Select(a => a.Street).ToArray());
            flatenned.ToList().ForEach(Console.WriteLine);
        }
        private static List<Customer> GetAllCustomers()
        {
            return new List<Customer>
                       {
                           new Customer
                               {
                                   FirstName = "Joe",
                                   LastName = "Blow",
                                   CreditCards = new List<CreditCard>
                                                     {
                                                         new CreditCard
                                                             {
                                                                 Name = "Visa"
                                                             },
                                                         new CreditCard
                                                             {
                                                                 Name = "Master Card"
                                                             }
                                                     },
                                   Addresses = new List<Address>
                                                   {
                                                       new Address
                                                           {
                                                               Street = "38 Oak Street"
                                                           },
                                                       new Address
                                                           {
                                                               Street = "432 Main Avenue"
                                                           }
                                                   }
                               },
                           new Customer
                               {
                                   FirstName = "Sally",
                                   LastName = "Cupcake",
                                   CreditCards = new List<CreditCard>
                                                     {
                                                         new CreditCard
                                                             {
                                                                 Name = "Discover"
                                                             },
                                                         new CreditCard
                                                             {
                                                                 Name = "Master Card"
                                                             }
                                                     },
                                   Addresses = new List<Address>
                                                   {
                                                       new Address
                                                           {
                                                               Street = "29 Maple Grove"
                                                           },
                                                       new Address
                                                           {
                                                               Street = "887 Nut Street"
                                                           }
                                                   }
                               }
                       };
        }
    }
}
