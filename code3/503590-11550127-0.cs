    protected override void OnDocumentLoading(EventArgs e)
        {
            mRes = new ResolveEventHandler(CustomAssemblyResolverDocData);
            availableTypes = new Dictionary<string, Type>();
            availableAssemblies = new Dictionary<string, Assembly>();
            PreloadAssemblies();
            if (availableAssemblies.Count == 0)
                throw new Exception("Problem");
            
            base.OnDocumentLoading(e);
            AppDomain.CurrentDomain.TypeResolve += mRes;
            AppDomain.CurrentDomain.AssemblyResolve += mRes;
        }
