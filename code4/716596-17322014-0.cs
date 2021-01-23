    [Range(...)]
    public long DateTimeLong { get; set; }
    
    public DateTime DateTime { get { return new DateTime(DateTimeLong); }
                               set { DateTimeLong = new DateTime(value); } }
