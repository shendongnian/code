    using System;
    using System.Reflection;
    
    public class Foo
    {
        public string Bar { get; set; }
    }
    
    public class Program
    {
        static void Main()
        {
            string name = "Foo";
            string property = "Bar";
            string value = "Baz";
    
            // Get the type contained in the name string
            Type type = Type.GetType(name, true);
    
            // create an instance of that type
            object instance = Activator.CreateInstance(type);
    
            // Get a property on the type that is stored in the 
            // property string
            PropertyInfo prop = type.GetProperty(property);
    
            // Set the value of the given property on the given instance
            prop.SetValue(instance, value, null);
    
            // at this stage instance.Bar will equal to the value
            Console.WriteLine(((Foo)instance).Bar);
        }
    }
