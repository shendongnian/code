    public double Value {get;set;}
    [ProtoMember(4)]
    public int ValueInt32 {
        get { return (int)Math.Round(100 * Value); }
        set { Value = value/100.0; }
    }
    
