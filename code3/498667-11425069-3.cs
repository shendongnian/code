    public bool IsInSession
    {
        get {
            return DateTime.UTCNow >= StartTimeUtc && DateTime.UTCNow <= EndTimeUtc;
        }
    }
     
