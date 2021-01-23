       public class CustomerSource
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
    
            public int NumberOfOrders { get; set; }
        }
    
        public class CustomerTarget
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
    
            public int NumberOfOrders { get; set; }
        }
    
        [TestMethod]
        public void Test_AutoMapper()
        {
            Mapper.CreateMap<CustomerSource, CustomerTarget>();
    
            var source = new CustomerSource() { DateOfBirth = DateTime.Now, FirstName = "FirstName", LastName = "LastName", NumberOfOrders = int.MaxValue };
    
            var res1 = Mapper.Map<CustomerSource, CustomerTarget>(source);
            Console.WriteLine(res1.FirstName); // PRINT FirstName
    
            source.FirstName += "[UPDATED]";
            source.LastName += "[UPDATED]";
    
            var res2 = Mapper.Map<CustomerSource, CustomerTarget>(source);
            Console.WriteLine(res1.FirstName); // PRINT FirstName[UPDATED]
           
        }
 
