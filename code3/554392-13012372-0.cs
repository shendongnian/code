    public class UnitTestBase
    {
        static DataTests()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
        }
        public static Assembly CurrentDomainAssemblyResolve(
            object sender, ResolveEventArgs args)
        {
            var name = new AssemblyName(args.Name);
            return name.Name == "Ninject" 
                ? typeof(KernelBase).Assembly : null;
        }
    }
