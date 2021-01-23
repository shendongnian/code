    public Person Child
    {
        get
        {
            return _child ?? GetChildFromContext();
        }
    }
