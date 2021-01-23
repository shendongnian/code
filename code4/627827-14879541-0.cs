    private int? stateId;
    public int StateId
    {
        get { return stateId ?? State.Id; }
        set { stateId = value; }
    }
