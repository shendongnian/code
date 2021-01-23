    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
        {
            string file = typeof(Test).Assembly
                                      .ManifestModule
                                      .FullyQualifiedName;
            Console.WriteLine(file);
            DateTime lastWriteTime = File.GetLastWriteTime(file);
            Console.WriteLine(lastWriteTime);
        }
    }
