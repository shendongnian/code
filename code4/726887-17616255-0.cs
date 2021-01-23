    public DateTime InputTime(DateTime time) {
        if (time.Kind == DateTimeKind.Unspecified) {
            throw new ArgumentException("Time values cannot be input to the data store with unspecified kind.");
        }
        return time.ToUniversalTime();
    }
    
    public DateTime OutputTime(DateTime time) {
        if (time.Kind == DateTimeKind.Unspecified) {
            time = DateTime.SpecifyKind(time, DateTimeKind.Utc);
        }
        return time.ToUniversalTime();
    }
