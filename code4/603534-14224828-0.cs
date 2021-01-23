    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace PopulateFromAttributes
    {
    class Program
    {
        static void Main(string[] args)
        {
            // Set up some test data - an address in a Container
            var attributeData = new List<Attributes> 
            {
                new Attributes { Name = "Line1", Value = "123 Something Avenue" },
                new Attributes { Name = "City", Value = "Newville" },
                new Attributes { Name = "State", Value = "New York" },
                new Attributes { Name = "Zip", Value = "12345" },
            };
            Container container = new Container { Type = "Address", Attributes = attributeData };
            // Instantiate and Populate the object
            object populatedObject = CreateObjectFromContainer("PopulateFromAttributes", container);
            Address address = populatedObject as Address;
            // Output values
            Console.WriteLine(address.Line1);
            Console.WriteLine(address.City);
            Console.WriteLine(address.State);
            Console.WriteLine(address.Zip);
            Console.ReadKey();
        }
        /// <summary>
        /// Creates the object from container.
        /// </summary>
        /// <param name="objectNamespace">The namespace of the Type of the new object.</param>
        /// <param name="container">The container containing the object's data.</param>
        /// <returns>Returns a newly instantiated populated object.</returns>
        private static object CreateObjectFromContainer(string objectNamespace, Container container)
        {
            // Get the Type that we need to populate and instantiate an object of that type
            Type newType = Type.GetType(string.Format("{0}.{1}", objectNamespace, container.Type));
            object newObject = Activator.CreateInstance(newType);
            // Pass each attribute and populate the values
            var properties = newType.GetProperties();
            foreach (var property in properties)
            {
                var singleAttribute = container.Attributes.Where(a => a.Name == property.Name).FirstOrDefault();
                if (singleAttribute != null)
                {
                    property.SetValue(newObject, singleAttribute.Value, null);
                }
            }
            return newObject;
        }
    }
    public class Container
    {
        public string Type { get; set; }
        public IEnumerable<Attributes> Attributes { get; set; }
        public IEnumerable<Container> RelatedContainers { get; set; }
    }
    public class Attributes
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Address
    {
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
    }
