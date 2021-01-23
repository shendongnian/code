    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    class Program
    {
        static void Main(string[] args)
        {
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "foo.exe", true);
            parameters.GenerateExecutable = true;
            CompilerResults results = csc.CompileAssemblyFromSource(parameters,
            @"using System.Linq;
                class Program {
                  public static void Main(string[] args) {
                    var q = from i in Enumerable.Rnge(1,100)
                              where i % 2 == 0
                              select i;
                  }
                }");
            results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
        }
    }
