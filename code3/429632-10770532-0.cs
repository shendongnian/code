        static void Main(string[] args)
        {
            string sourceCode = @"namespace Dynamic {
    using System.Linq;
    using System.Collections.Generic;
    public static class Query
    {
        public static int GetRecords()
        {
            MyApp.Data.DataMart container = new MyApp.Data.DataMart();
            //return (container.EventDetails).Count();
            return (from e in container.EventDetails select e).Count();
        }
    } }";
            string sDynamDll = "Dynamic.dll";
            string sDynamClass = "Query";
            string sDynamMethod = "GetRecords";
            System.CodeDom.Compiler.CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            cp.OutputAssembly = sDynamDll;
            cp.ReferencedAssemblies.Add("mscorlib.dll");
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Core.dll");
            cp.ReferencedAssemblies.Add("System.Data.Linq.dll");
            cp.ReferencedAssemblies.Add("System.Data.Entity.dll");
            cp.ReferencedAssemblies.Add("MyApp.Data.dll");
            var providerOptions = new Dictionary<string, string>();
            providerOptions.Add("CompilerVersion", "v4.0");
            CodeDomProvider compiler = CodeDomProvider.CreateProvider("C#", providerOptions);
            CompilerResults cr = compiler.CompileAssemblyFromSource(cp, sourceCode);
            if (cr.Errors.HasErrors)
            {
                StringBuilder errors = new StringBuilder("Compiler Errors :\r\n");
                foreach (CompilerError error in cr.Errors)
                {
                    errors.AppendFormat("Line {0},{1}\t: {2}\n", error.Line, error.Column, error.ErrorText);
                }
            }
            // verify assembly
            Assembly theDllAssembly = null;
            if (cp.GenerateInMemory)
                theDllAssembly = cr.CompiledAssembly;
            else
                theDllAssembly = Assembly.LoadFrom(sDynamDll);
            Type theClassType = theDllAssembly.GetType(sDynamClass);
            foreach (Type type in theDllAssembly.GetTypes())
            {
                if (type.IsClass == true)
                {
                    if (type.FullName.EndsWith("." + sDynamClass))
                    {
                        theClassType = type;
                        break;
                    }
                }
            }
            // invoke the method
            if (theClassType != null)
            {
                object[] method_args = new object[] { };
                Object rslt = theClassType.InvokeMember(
                    sDynamMethod,
                  BindingFlags.Default | BindingFlags.InvokeMethod,
                       null,
                       null, // for static class
                       method_args);
                Console.WriteLine("Results are: " + rslt.ToString());
            }
            Console.ReadKey();
        }
