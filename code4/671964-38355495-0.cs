    protected override IEnumerable<ModuleRegistration> Modules
    {
        get
        {
            return
                AppDomainAssemblyTypeScanner
                        .TypesOf<INancyModule>(ScanMode.All)
                        .NotOfType<DiagnosticModule>()
                        .Select(t => new ModuleRegistration(t))
                        .ToArray();
        }
    }
