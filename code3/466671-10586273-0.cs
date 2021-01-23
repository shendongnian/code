    private int prop;
    public object Property
    {
        get { return this.prop; }
        set
        {
            this.prop = value != null ? Int32.Parse(value.ToString()) : 0;
        }
    }
