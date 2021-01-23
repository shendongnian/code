    public class TypeOne
        {
            public int OrderId { get; set; }
            public string SomeOtherField { get; set; }
        }
    
        public class TypeTwo
        {
            public int OrderId { get; set; }
            public string MainField { get; set; }
        }
        
        
        class Program
        {
            static void Main(string[] args)
            {
                // A little bit of setup
                var first = new List<TypeOne>() { new TypeOne { OrderId = 1, SomeOtherField = "One" }, new TypeOne { OrderId = 2,  SomeOtherField = "Two" } } ;
                var second = new List<TypeTwo>() { new TypeTwo { OrderId = 1, MainField = "One" }, new TypeTwo { OrderId = 2, MainField = "Two" }, new TypeTwo { OrderId = 3, MainField = "Buckle" }, new TypeTwo { OrderId = 4, MainField = "MyShoe" } };
    
                // Here's where we do the interesting bit
                var firstIds = from id in first
                               select id.OrderId;
    
                var query = from item in second
                            where firstIds.Contains(item.OrderId)
                            select item;
    
    
                // And some boring results
                foreach (var i in query)
                {
                    Console.WriteLine(string.Format("[OrderId: {0}, MainField: {1}]", i.OrderId, i.MainField));
                }
    
                Console.ReadLine();
    
            }
