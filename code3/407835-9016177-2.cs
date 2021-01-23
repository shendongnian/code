    using System;
    using System.Dynamic;
    using System.Xml.Linq;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Creation and population of the ExpandoObject    
                // Add as many or few properties as you like. 
                // Property Types are set at runtime and for the lifetime of the
                // property 
                // Expando objects also support dynamic methods. 
                dynamic wrapper = new ExpandoObject(); 
                wrapper.FirstProperty = "Hello";
                wrapper.SecondProperty = "Dynamic";
                wrapper.AnotherProperty = "World!";
                wrapper.AnyTypeProperty = 1234;
                wrapper.XDocumentProperty = new XDocument();
                // etc 
                // Passing of ExpandoObject
                PassWrapperToFunction(wrapper);
                Console.ReadLine();
            }
            // .. 
            // Function signature of recipient
            private static void PassWrapperToFunction(dynamic wrapper)
            {
                Console.WriteLine("{0} {1} {2} {3}\n", 
                    wrapper.FirstProperty, 
                    wrapper.SecondProperty,
                    wrapper.AnotherProperty, 
                    wrapper.AnyTypeProperty);
                Console.WriteLine("Parameter types:\n{0}\n{1}\n{2}\n{3}\n{4}",
                    wrapper.FirstProperty.GetType(), 
                    wrapper.SecondProperty.GetType(),
                    wrapper.AnotherProperty.GetType(), 
                    wrapper.AnyTypeProperty.GetType(), 
                    wrapper.XDocumentProperty.GetType());
            } 
        }
    }
