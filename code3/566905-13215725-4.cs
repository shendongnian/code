    using System;
    using System.Linq;
    using System.Reflection;
    
    namespace GenericParametersViaReflectionTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Note: we're using the type without specifying a type for <T>.
                var classType = typeof(MyClass<>);
    
                foreach (MethodInfo method in classType.GetMembers()
                    .Where(method => method.Name == "MyMethod"))
                {
                    // Iterate through each parameter of the method
                    foreach (var param in method.GetParameters())
                    {
                        // For generic methods, the name will be "T" and the FullName
                        // will be null; you can use which ever check you prefer.
                        if (param.ParameterType.Name == "T"
                            || param.ParameterType.FullName == null)
                            Console.WriteLine("We found our generic method!");
                        else
                            Console.WriteLine("We found the non-generic method:");
                        
                        Console.WriteLine("Method Name: {0}", method.Name);
                        Console.WriteLine("Parameter Name: {0}", param.Name);
                        Console.WriteLine("Type: {0}", param.ParameterType.Name);
                        Console.WriteLine("Type Full Name: {0}",
                            param.ParameterType.FullName ?? "null");
                        Console.WriteLine("");
                    }   
                }
                Console.Read();
            }
        }
        public class MyClass<T>
        {
            public void MyMethod(T a) { }
            public void MyMethod(int a) { }
        }
    }
