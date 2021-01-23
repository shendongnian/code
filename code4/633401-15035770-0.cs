    [DataMember(Name = "IS_PAID")]
    public string isPaidString { get; set; }
    public bool isPaid
    {
        get {return isPaidString == "T";}
        set {isPaidString = value ? "T" : "F";}
    }
