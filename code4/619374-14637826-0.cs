    public int SomeVariable
    {
        get { return someVariable; }
        set
        {
            if(value > 5)
                throw new InvalidOperationException("SomeVariable cannot be greater than 5.");
            someVariable = value;
        }
    }
