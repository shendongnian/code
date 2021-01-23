    AssemblyDefinition asm = AssemblyFactory.GetAssembly("myassembly.dll");
    
    foreach (ModuleDefinition module in asm.Modules)
    {
        Console.WriteLine("Module " + module.Name);
        Console.WriteLine("IsPE64 " + module.Image.PEOptionalHeader.StandardFields.IsPE64);
    }
