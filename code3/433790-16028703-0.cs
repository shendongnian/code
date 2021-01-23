    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
    Method1()
    {
        Process.Start(...);
    }
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
    Method2()
    {
        Method1();
    }
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
    Method3()
    {
        Method2();
    }
    [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
    Method4()
    {
        Method3();
    }
    ...
    ...
