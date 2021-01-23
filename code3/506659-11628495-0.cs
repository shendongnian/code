    private int bar = 6; // default value of 6
    public int Bar { get { return bar;} set { bar = value;}}
    public bool ShouldSerializeBar()
    {
        return Bar != 6;
    }
