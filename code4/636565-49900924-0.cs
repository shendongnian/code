    private readonly string[] _extensions = { ".dll", ".exe", ".pdb", ".dll.config", ".exe.config" };
    
    private string[] GetDependentFiles(Assembly assembly)
    {
        AssemblyName[] asm = assembly.GetReferencedAssemblies();
        List<string> paths = new List<string>(asm.Length);
        for (int t = asm.Length - 1; t >= 0; t--)
        {
            for (int e = _extensions.Length - 1; e >= 0; e--)
            {
                string path = Path.GetFullPath(asm[t].Name + _extensions[e]);
                if (File.Exists(path)) paths.Add(path);
            }
        }
    
        return paths.ToArray();
    }
