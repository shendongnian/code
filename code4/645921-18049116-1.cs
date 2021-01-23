    using System;
    using System.Reflection;
    
    [assembly:AssemblyVersion("1.1.0.0")]
    
    class Example
    {
        static void Main()
        {
            Console.WriteLine("The version of the currently executing assembly is: {0}",
              Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
