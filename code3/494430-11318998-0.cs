    // Only members of the SpecialClients group can call this method.
    [PrincipalPermission(SecurityAction.Demand, Role = "SpecialClients")]
    public void DoSomething()
    { 
    }
