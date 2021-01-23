    DateTime GetClosestTime(DateTime testTimeValue, List<DateTime> listItems) {
    
        TimeSpan lastSpan = TimeSpan.MaxValue;
        DateTime dtMatch = DateTime.Now;
    
        foreach (DateTime dt in listItems) {
            var diff = (testTimeValue - dt).Duration();
            if (diff < lastSpan) {
                lastSpan = diff;
                dtMatch = dt;
            }
        }
    
        return dtMatch;
    }
