    private Lazy<string> m_someMember = new Lazy<string>(GetSomeMember);
    protected string SomeMember
    {
        get { return m_someMember.Value; }
    }
