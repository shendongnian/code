    public static void Main()
    {            
         AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyNotFoundEventHandler);
    
         InvokeExternalType();
    }
    
    private static Assembly ResolveEventHandler(object sender, ResolveEventArgs args)
    {
        MessageBox.Show("Error, can't find assembly: " + args.Name, "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
        return null;
    }
    
    private static void InvokeExternalType()
    {
        MyClass doc = ... // from an external assembly.
    }
