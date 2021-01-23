    using System;
    using System.Xml.Linq;
    using System.Linq;
    using System.IO;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.Linq.Expressions;
    class Program
    {
        private const string classTemplate = @"
                using System;
                using System.Linq.Expressions;
    
                public static class RulesConfiguration
                {{
                    private static Expression<Func<string, bool>>[] rules = new Expression<Func<string, bool>>[]
                    {{
                        {0}
                    }};
    
                    public static Expression<Func<string, bool>>[] Rules {{ get {{ return rules; }} }}
                }}
            ";
        static void Main(string[] args)
        {
            var filePath = @"c:\temp\rules.txt";
            var fileContents = File.ReadAllLines(filePath);
            // add commas to the expressions so they can compile as part of the array
            var joined = String.Join("," + Environment.NewLine, fileContents);
            Console.WriteLine("Rules found in file: \n{0}", joined);
            var classSource = String.Format(classTemplate, joined);
            var assembly = CompileAssembly(classSource);
            var rules = GetExpressionsFromAssembly(assembly);
            foreach (var rule in rules)
            {
                var compiledToFunc = rule.Compile();
                Console.WriteLine("Checking rule {0} against input {1}: {2}", rule, filePath, compiledToFunc(filePath));
            }
        }
        static Expression<Func<string, bool>>[] GetExpressionsFromAssembly(Assembly assembly)
        {
            var type = assembly.GetTypes().Single();
            var property = type.GetProperties().Single();
            var propertyValue = property.GetValue(null, null);
            return propertyValue as Expression<Func<string, bool>>[];
        }
        static Assembly CompileAssembly(string source)
        {
            var compilerParameters = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                ReferencedAssemblies =
                {
                    "System.Core.dll" // needed for linq + expressions to compile
                },
            };
            var compileProvider = new CSharpCodeProvider();
            var results = compileProvider.CompileAssemblyFromSource(compilerParameters, source);
            if (results.Errors.HasErrors)
            {
                Console.Error.WriteLine("{0} errors during compilation of rules", results.Errors.Count);
                foreach (CompilerError error in results.Errors)
                {
                    Console.Error.WriteLine(error.ErrorText);
                }
                throw new InvalidOperationException("Broken rules configuration, please fix");
            }
            var assembly = results.CompiledAssembly;
            return assembly;
        }
    }
