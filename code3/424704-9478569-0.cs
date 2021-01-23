    using System;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    
    class Test
    {
        static void Main()
        {
            var provider = new CSharpCodeProvider();
            var options = new CompilerParameters {
                OutputAssembly = "Foo.dll"
            };
            string source = "public class Foo {}";
            
            provider.CompileAssemblyFromSource(options, new[] { source });
        }
    }
