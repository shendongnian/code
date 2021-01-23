    enum MonthOfTheYear : byte {
            January,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
    for (int i = 0; i < 12; i++) {
        Console.WriteLine(String.Format("{0} has integer value of {1}", Enum.GetName(typeof(MonthOfTheYear), i), i));
    }
