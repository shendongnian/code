    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Dynamic;
    
    class MyObject
    {
        // Some properties
        public string PropertyA { get; set; }
        public string PropertyB { get; set; }
        public DateTime? PropertyC { get; set; }
    
        static void Main(string[] args)
        {
            // Our repository
            var list = new List<MyObject>() {
                    new MyObject() { PropertyA = "test"} ,
                    new MyObject() { PropertyB = "test"} ,
                    new MyObject() { PropertyC = DateTime.Today} ,
                    new MyObject() { PropertyC = DateTime.Today,
                                     PropertyA = "test"} 
                };
            
            // Loop through the filtered results
            // (calling our GetByExample method with a
            // new object with a property set)
            foreach (var obj in 
                     GetByExample(list,
                                  new MyObject() { PropertyC = DateTime.Today }))
            {
                // Write some output so we can see it working
                Console.WriteLine("Found object");
                Console.WriteLine(obj.PropertyA);
                Console.WriteLine(obj.PropertyB);
                Console.WriteLine(obj.PropertyC);
            }
    
            // Wait for the user to press a key before we close
            Console.ReadKey();
        }
    
        static IQueryable<MyObject> GetByExample(List<MyObject> objects,
                                                 MyObject filterObj)
        {
            // Create our query variable that we'll add to
            var filteredObjects = objects.AsQueryable();
            
            // Loop through each property on this object
            foreach (var prop in filterObj.GetType().GetProperties())
            {
                // Get the value of this property
                var propVal = prop.GetValue(filterObj, null);
    
                if (propVal != null)
                {
                    // If the property isn't null add a where clause
                    filteredObjects =
                        filteredObjects.Where(string.Format("{0} = @0",
                                                            prop.Name),
                                              propVal);
                }
            }
    
            return filteredObjects;
        }
    }
