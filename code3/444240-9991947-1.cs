    using System;
    using System.IO;
    using System.Reflection;
    
    class Program
    {
        static void Main(string[] args)
        {
            var assemblies = Directory.GetFiles("C:\\Windows\\Microsoft.NET\\Framework" + (Environment.Is64BitProcess ? "64" : "") + "\\v4.0.30319", "*.dll");
            foreach(var assembly in assemblies)
            {
                try
                {
                    var loadedAssembly = Assembly.LoadFrom(assembly);
                    var types = loadedAssembly.GetTypes();
                    foreach(var type in types)
                        if(type.IsAbstract && type.IsClass)
                            Console.WriteLine(type.FullName);
                }
                catch
                {
                    // Not an assembly? Ignore.
                }   
            }
        }
    }
