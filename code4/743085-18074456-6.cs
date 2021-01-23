    private readonly Scope _dontDoThisScope = new Scope();
    public string MyProperty
    {
        set
        {
            using (new ScopeGuard (_dontDoThisScope))
                Property = value;
        }
    }
