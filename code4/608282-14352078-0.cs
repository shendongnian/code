    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
    	AppDomain domain = (AppDomain)sender;
    	if (args.Name.Contains("YourDll"))
    	{
    		return domain.Load(WindowsFormsApplication1.Properties.Resources.YourDll);
    	}
    	return null;
    }
