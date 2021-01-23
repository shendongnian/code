    private static readonly TimeSpan MinimumTimeSpan = new TimeSpan(0,5,0);
    IEnumerable<Record> getSparseRecords(IEnumerable<Record> allRecords)
    {
        DateTime previous = DateTime.MinValue;
        foreach(var record in allRecords)
        {
            TimeSpan dif = record.DateTime - previous;
            if (dif >= MinimumTimeSpan)
            {
                previous = record.DateTime;
                yield return record;
            }
        }
    }
