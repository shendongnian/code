    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    
    class Test
    {
        public static void Main(string[] args)
        {
            var compiler = new CSharpCodeProvider();
            var parameters = new CompilerParameters { 
                CompilerOptions = "/unsafe"
            };
            var source = "unsafe struct Foo {}";
            var result = compiler.CompileAssemblyFromSource(parameters, source);
            // No errors are shown with the above options set
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error);
            }
        }
    }
