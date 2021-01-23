    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
    ...
    var instream = new FileStream("test.xml", FileMode.Open);
    var conf = ser.ReadObject(instream);
    ...
    
    private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (args.Name == "ClassLibrary2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null") // adapt to your needs of course
            return Assembly.LoadFrom(@"mypath\ClassLibrary2.dll");
             
        return null; // don't know for this one
    }
