            var criteriaFunctions = GetCriteriaFunctions<Customer, CustomerCriteria>();
            var customer1 = new Customer { Name = "John", Age = 35, IsNew = false };
            var customer2 = new Customer { Name = "Mary", Age = 27, IsNew = true };
            var criteria1 = new CustomerCriteria { Age = 35 };
            var criteria2 = new CustomerCriteria { IsNew = true };
            Console.WriteLine("Is match: {0}", criteriaFunctions.All(f => f(customer1, criteria1)));
            Console.WriteLine("Is match: {0}", criteriaFunctions.All(f => f(customer2, criteria1)));
            Console.WriteLine("Is match: {0}", criteriaFunctions.All(f => f(customer1, criteria2)));
            Console.WriteLine("Is match: {0}", criteriaFunctions.All(f => f(customer2, criteria2)));
