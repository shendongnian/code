    $Source = @" 
    using System;
    using System.Linq;
    
    namespace Testing
    {
        public static class TestClass
        {
            public static void DoTest()
            {
                 var myLinq = "hello world";
                 Console.WriteLine(myLinq.ToString());
        }
        }
    }
    "@
    
    $null = Add-Type -ReferencedAssemblies system.core -TypeDefinition $Source -Language Csharp
