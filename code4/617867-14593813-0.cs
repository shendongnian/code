    private Workspace _workspace;
    public virtual Workspace Workspace
    {
        get { return _workspace; }
        set
        {
            if (value != null)
            {
                _workspace = value;
            }
        }
    }
