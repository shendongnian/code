    using System;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    using System.Reflection;
    
    namespace ConsoleApplication52
    {
        static class MathEvaluator
        {
            private const string Begin = @"using System;
    namespace MyNamespace
    {
        public static class LambdaCreator 
        {
            public static Func<double,double> Create()
            {
                return (x)=>";
            private const string End = @";
            }
        }
    }";
        public static Delegate Parse(string input)
        {
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters {GenerateInMemory = true};
            parameters.ReferencedAssemblies.Add("System.dll");
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, Begin + input + End);
            var cls = results.CompiledAssembly.GetType("MyNamespace.LambdaCreator");
            var method = cls.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            return (method.Invoke(null, null) as Delegate);
        }
    }
    
    class Program
    {
        private static void Main()
        {
            string middle = Console.ReadLine();
            var del = MathEvaluator.Parse(middle);
            Console.WriteLine(del.DynamicInvoke(5));
            Console.ReadKey();
        }
    }
    }
