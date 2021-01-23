        // works for any loaded assembly, regardless of the path
        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            // you may not want to use First() here, consider FirstOrDefault() as well
            var asm = (from a in AppDomain.CurrentDomain.GetAssemblies()
                      where a.GetName().FullName == args.Name
                      select a).First();
            return asm;
        }
        // set it as follows somewhere in the beginning of your program:
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
