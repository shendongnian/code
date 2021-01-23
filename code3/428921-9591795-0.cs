    using System;
    using System.Collections;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    
    namespace Foo {}
    
    class Program
    {
        static void Main(string[] args)
        {
            var referencedDll = new List<string>
            {
                "mscorlib.dll",
                "System.dll",
                "System.Core.dll",
            };
    
            var parameters = new CompilerParameters(
                 assemblyNames: referencedDll.ToArray(),
                 outputName: "foo.dll",
                 includeDebugInformation: false)
            {
                TreatWarningsAsErrors = true,
                // We don't want to be warned that we have no await!
                WarningLevel = 0,
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            
            var source = new[] { "class Test { static async void Foo() {}}" };
    
            var options = new Dictionary<string, string> {
                 { "CompilerVersion", "v4.0" }
            };
            var compiler = new CSharpCodeProvider(options);
            var results = compiler.CompileAssemblyFromSource(parameters, source);
    
            Console.WriteLine("Success? {0}", !results.Errors.HasErrors);
        }
    }
