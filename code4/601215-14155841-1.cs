    AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
    private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
        Assembly loadedAssembly = args.LoadedAssembly;
    
        if (!VerifytrongNameSignature(loadedAssembly))
            // Do whatever you want when the signature is broken.
    }
    
    private static bool VerifytrongNameSignature(Assembly assembly)
    {
         byte wasVerified = 0;
    
         return NativeMethods.StrongNameSignatureVerificationEx(assembly.Location, 1, ref wasVerified);
    }
