    private Person _child = null;
    public Person Child
    {
        get
        {
            return _child ?? GetandSetChildFromContext();
        }
    }
