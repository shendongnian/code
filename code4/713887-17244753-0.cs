    using System;
    using System.Collections.Generic;
     
    class Foo {
        public int Bar { get; set; }
        public Foo(Dictionary<string, object> values) {
            var propertyInfo = this.GetType().GetProperties();
            foreach(var property in propertyInfo) {
                if(values.ContainsKey(property.Name)) {
                    property.SetValue(this, values[property.Name], null);
                }
            }
        }
    }
     
    class Program {
        public static void Main(String[] args) {
            Dictionary<string, object> values = new Dictionary<string, object>();
            values.Add("Bar", 42);
            Foo foo = new Foo(values);
            Console.WriteLine(foo.Bar); // expect 42
        }
    }
