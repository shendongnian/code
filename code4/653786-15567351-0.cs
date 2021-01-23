    public Int64 TimeSpanTicks{ get; set; }     
    [NotMapped]
    public TimeSpan TimeSpanValue
    {
        get { return TimeSpan.FromTicks(TimeSpanTicks); }
        set { TimeSpanTicks= value.Ticks; }
    }
 
