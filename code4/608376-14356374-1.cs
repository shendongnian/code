    static IEnumerable<Diff> GetDiffs(YourContext context)
    {
        bool? checkedIn;
        DateTime lastDate;
        foreach (var event in context.TimeEvents.OrderBy(te => te.EventDate))
        {
            if ((checkedIn.HasValue && checkedIn.Value = !event.CheckIn) ||
                    (!checkedIn.HasValue && event.CheckIn))
            {
                if (checkedIn.HasValue && !event.CheckIn)
                {
                    yield return new Diff
                    {
                        CheckInTime = lastDate;
                        CheckOutTime = event.EventDate;
                    };                    
                
                    checkedIn = event.CheckIn;
                    lastDate = event.EventDate;
                }
            }
        }
    }
