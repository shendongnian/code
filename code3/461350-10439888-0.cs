    using System;
    using System.IO;
    using System.Reflection;
     
    public class ReflectionOnlyLoadTest
    {
        public ReflectionOnlyLoadTest(String rootAssembly) {
            m_rootAssembly = rootAssembly;
        }
     
        public static void Main(String[] args)
        {
            if (args.Length != 1) {
                Console.WriteLine("Usage: Test assemblyPath");
                return;
            }
     
            try {
                ReflectionOnlyLoadTest rolt = new ReflectionOnlyLoadTest(args[0]);
                rolt.Run();
            }
     
            catch (Exception e) {
                Console.WriteLine("Exception: {0}!!!", e.Message);
            }
        }
     
        internal void Run() {
            AppDomain curDomain = AppDomain.CurrentDomain;
            curDomain.ReflectionOnlyPreBindAssemblyResolve += new ResolveEventHandler(MyReflectionOnlyResolveEventHandler);
            Assembly asm = Assembly.ReflectionOnlyLoadFrom(m_rootAssembly);
     
            // force loading all the dependencies
            Type[] types = asm.GetTypes();
     
            // show reflection only assemblies in current appdomain
            Console.WriteLine("------------- Inspection Context --------------");
            foreach (Assembly a in curDomain.ReflectionOnlyGetAssemblies())
            {
                Console.WriteLine("Assembly Location: {0}", a.Location);
                Console.WriteLine("Assembly Name: {0}", a.FullName);
                Console.WriteLine();
            }
        }
     
        private Assembly MyReflectionOnlyResolveEventHandler(object sender, ResolveEventArgs args) {
            AssemblyName name = new AssemblyName(args.Name);
            String asmToCheck = Path.GetDirectoryName(m_rootAssembly) + "\\" + name.Name + ".dll";
            if (File.Exists(asmToCheck)) {
                return Assembly.ReflectionOnlyLoadFrom(asmToCheck);
            }
            return Assembly.ReflectionOnlyLoad(args.Name);
        }
     
        private 
