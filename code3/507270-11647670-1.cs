    class Program
    {
        static void Main(string[] args)
        {
            string assemblyName = Path.Combine(Path.GetTempPath(), string.Format("temp{0}.dll", Guid.NewGuid()));
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters(new string[]
            {
                "System.dll",
                "Microsoft.CSharp.dll",
            }, assemblyName);
            CompilerResults cr = codeProvider.CompileAssemblyFromSource(compilerParameters, File.ReadAllText("Program.cs"));
            if (cr.Errors.Count > 0)
            {
                foreach (CompilerError error in cr.Errors)
                {
                    Console.WriteLine(error.ErrorText);
                }
            }
            else
            {
                Assembly assembly = Assembly.LoadFrom(assemblyName);
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    Console.WriteLine(type.Name);
                    MethodInfo[] mis = type.GetMethods();
                    foreach (MethodInfo mi in mis)
                    {
                        Console.WriteLine("\t" + mi.Name);
                    }
                }
            }
            Console.ReadLine();
        }
    }
