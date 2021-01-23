    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Microsoft.CSharp;
    
    namespace ConsoleApplication52
    {
        class MathEvaluator
        {
            public readonly Delegate ParsedFunction;
            public double Invoke(double x)
            {
                if (ParsedFunction == null)
                    throw new NullReferenceException("No function to invoke");
                return (double) ParsedFunction.DynamicInvoke(x);
            }
            private const string Begin = 
                @"using System;
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
        public MathEvaluator(string input)
        {
            string normalized = Normalize(input);
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters {GenerateInMemory = true};
            parameters.ReferencedAssemblies.Add("System.dll");
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, Begin + normalized + End);
            var cls = results.CompiledAssembly.GetType("MyNamespace.LambdaCreator");
            var method = cls.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            ParsedFunction = (method.Invoke(null, null) as Delegate);
        }
        public string Normalize(string input)
        {
            return input.ReplaceMultipling().ReplacePow();
        }
    }
    public static class StringHelper
    {
        public static string ReplaceMultipling(this string input)
        {
            return Regex.Replace(input, @"(\d+)(x)", @"$1*$2");
        }
        public static string ReplacePow(this string input)
        {
            return Regex.Replace(input, @"(\(?\d*x\)?)\^(\d+)", "Math.Pow($1,$2)");
        }
    }
    }
...
    using System;
    namespace ConsoleApplication52
    {
        class Program
        {
            private static void Main()
            {
                const string input = "2x^2+3x";
                var ev = new MathEvaluator(input);
                Console.WriteLine(ev.Invoke(2));
                Console.ReadKey();
            }
        }
    }
