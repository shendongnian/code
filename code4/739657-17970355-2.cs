    Private System.Reflection.Assembly OnAssemblyResolveHandler(Object sender, ResolveEventArgs args)
    {
        if (args.Name.StartsWith("assemblyName,")) { Return System.Reflection.Assembly.LoadFrom(@"pathOf3rdPartyAssembly"); }
        return null;
    }
