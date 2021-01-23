    using System;
    using System.CodeDom.Compiler;
    using System.IO;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Microsoft.CSharp;
    
    namespace MathEvalNS
    {
    public class MathEvaluator
    {
        private readonly Delegate parsedFunction;
        private readonly string normalized;
        public double Invoke(double x)
        {
            if (parsedFunction == null)
                throw new NullReferenceException("No function to invoke");
            return (double)parsedFunction.DynamicInvoke(x);
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
            normalized = Normalize(input);
            var provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters { GenerateInMemory = true };
            parameters.ReferencedAssemblies.Add("System.dll");
            CompilerResults results = provider.CompileAssemblyFromSource(parameters, Begin + normalized + End);
            try
            {
                var cls = results.CompiledAssembly.GetType("MyNamespace.LambdaCreator");
                var method = cls.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
                parsedFunction = (method.Invoke(null, null) as Delegate);
            }
            catch (FileNotFoundException)
            {
                throw new ArgumentException();
            }
        }
        private string Normalize(string input)
        {
            return input.ReplaceMath().ReplacePow().ReplaceMultipling().ReplaceToDoubles();
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
            var result = input.ReplacePow(@"(\d*x)\^(\d+\.?\d*)");
            return result.ReplacePow(@"\(([^\^]+)\)\^(\d+\.?\d*)");
        }
        private static string ReplacePow(this string input, string toReplace)
        {
            return Regex.Replace(input, toReplace, "Math.Pow($1,$2)");
        }
        public static string ReplaceToDoubles(this string input)
        {
            return Regex.Replace(input, @"(\d+)(?:[^\.]\d+)", "$1.0");
        }
        public static string ReplaceMath(this string input)
        {
            return
                input.ReplaceMath("sin", @"Math.Sin")
                     .ReplaceMath("cos", @"Math.Cos")
                     .ReplaceMath("ctg", @"1.0/Math.Tan")
                     .ReplaceMath("tg", @"Math.Tan");
        }
        private static string ReplaceMath(this string input, string name, string dotNetName)
        {
            return Regex.Replace(input, name, dotNetName, RegexOptions.IgnoreCase);
        }
    }
    }
