    // Be very careful when building this list, and make sure they're UTC times!
    private static readonly IEnumerable<DateTime> DstChanges = ...;
    static DateTime ConvertToLocalTime(DateTime utc)
    {
        int hours = 1; // Or 2, depending on the first entry in your list
        foreach (DateTime dstChange in DstChanges)
        {
            if (utc < dstChange)
            {
                return DateTime.SpecifyKind(utc.AddHours(hours), DateTimeKind.Local);
            }
            hours = 3 - hours; // Alternate between 1 and 2
        }
        throw new ArgumentOutOfRangeException("I don't have enough DST data!");
    }
