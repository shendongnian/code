    public IEnumerable<Reading> GetFirstAndLastInPeriod
        (IEnumerable<Reading> readings, DateTime begin, DateTime end)
    {
        return
            from reading in readings
            let span = readings.Where(item => item.time >= begin && item.time <= end)
            where reading.time == span.Max(item => item.time) 
                || reading.time == span.Min(item => item.time)
            select reading;            
    }
