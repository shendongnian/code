    static void RunInPartialTrust()
    {
        AppDomainSetup setup = new AppDomainSetup
        {
            ApplicationBase = Environment.CurrentDirectory
        };
 
        PermissionSet permissions = new PermissionSet(null);
        permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
        permissions.AddPermission(new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess));
        AppDomain appDomain = AppDomain.CreateDomain(
            "Partial Trust AppDomain",
            null,
            setup,
            permissions
        );
 
        Program p = (Program)appDomain.CreateInstanceAndUnwrap(
            typeof(Program).Assembly.FullName,
            typeof(Program).FullName
        );
 
        p.PartialTrustMain();
    }
