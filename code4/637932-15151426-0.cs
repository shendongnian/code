        static class MathEvaluator
    {
        private const string Begin = @"using System;
    namespace MyNamespace
    {
        public delegate double Del(double x);
        public static class LambdaCreator 
        {
            public static Del Create()
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
