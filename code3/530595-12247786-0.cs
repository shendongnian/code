    public DateTime NextRunDate { get; set; }
    public DateTime CompletedDate { get; set; }
    public Timespan Duration
    {
        get
        {
            return CompleteDate.Subtract(NextRunDate)
        }
    }
