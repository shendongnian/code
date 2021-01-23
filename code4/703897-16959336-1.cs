    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Person
    {
        public string Name { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
    public class PersonCollection : List<Person>
    {
        public object[] GetValues(string propertyName)
        {
            if (propertyName == "Name")
            {
                return this.Select(p => p.Name).ToArray();
            }
            else if (propertyName == "Property1")
            {
                return this.Select(p => p.Property1).ToArray();
            }
            else if (propertyName == "Property2")
            {
                return this.Select(p => p.Property1).ToArray();
            }
            // best way to implement this method?
            return null;
        }
    }
