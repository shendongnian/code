    public bool IsInSession
    {
        get {
            return DateTime.UTCNow >= StartTime && DateTime.UTCNow <= EndTime;
        }
    }
     
