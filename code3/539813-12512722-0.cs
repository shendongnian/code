    [DataMember]
    private int positiveValue;
    public int PositiveValue
    {
        get { return positiveValue; }
        set
        {
            if (value < 1)
                throw new ArgumentOutOfBoundException(...);
            positiveValue = value;
        }
    }
