    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
        var name = new AssemblyName(args.Name);
        string path = System.IO.Path.Combine(IntPtr.Size == 8 ? "x64" : "x86", name.Name + ".dll");
        path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), path);
        var asm = Assembly.LoadFrom(path);
        var found = new AssemblyName(asm.FullName);
        if (name.Version != found.Version) throw new System.IO.FileNotFoundException(name.FullName);
        return asm;
    }
