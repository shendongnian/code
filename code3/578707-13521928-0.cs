    public bool output
    {
        get
        {
            return !inputs.Any(i => !i);
        }
    }
