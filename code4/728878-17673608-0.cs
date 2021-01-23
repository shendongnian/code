    public ComboTree(IComboAction action)
        : base(action)
    {
        Movement = null; // <---- You are nulling Movement in the second constructor
    }
