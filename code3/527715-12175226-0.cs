    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.CSharp;
    
    
    namespace StaticAssembly
    {
        public class Program
        {
            public int xx = 1; // variable I want to access from the runtime code
    
            static void Main(string[] args)
            {
                CSharpCodeProvider provider = new CSharpCodeProvider();
                CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateInMemory = true;
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.ReferencedAssemblies.Add("StaticAssembly.exe");
    
                CompilerResults results = provider.CompileAssemblyFromSource(parameters, GetCode());
                var cls = results.CompiledAssembly.GetType("GeneratedAssembly.Program");
                var method = cls.GetMethod("DynamicMethod", BindingFlags.Static | BindingFlags.Public);
                var p = new Program();
                p.xx = 42;
                method.Invoke(null, new object[] {p});
    
                int a = int.Parse(Console.ReadLine()); // pause console
            }
    
    
            static string[] GetCode()
            {
                return new string[]
                {
                @"using System;
    
                namespace GeneratedAssembly
                {
                    class Program
                    {
                        public static void DynamicMethod(StaticAssembly.Program p)
                        {                        
                            Console.WriteLine(p.xx);
                            Console.WriteLine(""Hello, world!"");
                        }
                    }
                }"
                };
            }
        }
    }
