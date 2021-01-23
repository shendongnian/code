        List<DateRanges> aDateRanges = new List<DateRanges>();
        List<DateRanges> bDateRanges = new List<DateRanges>();
        aDateRanges.Add(new DateRanges(new DateTime(2012, 1, 1), new DateTime(2012, 1, 10)));
        aDateRanges.Add(new DateRanges(new DateTime(2012, 1, 11), new DateTime(2012, 1, 25)));
        bDateRanges.Add(new DateRanges(new DateTime(2012, 1, 2), new DateTime(2012, 1, 7)));
        bDateRanges.Add(new DateRanges(new DateTime(2012, 1, 8), new DateTime(2012, 1, 9)));
        bDateRanges.Add(new DateRanges(new DateTime(2012, 1, 15), new DateTime(2012, 1, 30)));
        DisplayDateRanges(GetGaps(aDateRanges, bDateRanges, 0), "Final Gap Fill");
        Console.WriteLine("Completed");
        Console.Read();
    }
    public class DateRanges
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateRanges(DateTime Start, DateTime End)
        {
            StartDate = Start;
            EndDate = End;
        }
    }
    public static void DisplayDateRanges(List<DateRanges> dateRanges, string title)
    {
        Console.WriteLine("************************{0}****************************", title);
        Console.WriteLine(Environment.NewLine + "New Recursion");
        foreach (DateRanges br in dateRanges)
        {
            Console.WriteLine("Start Date {0}   End Date {1}", br.StartDate, br.EndDate);
        }
    }
    public static List<DateRanges> GetGaps(List<DateRanges> aDateRanges, List<DateRanges> bDateRanges, int recursionlevel)
    {
        List<DateRanges> gapFill = new List<DateRanges>();
        List<DateRanges> gapFillTemp = new List<DateRanges>();
        List<DateRanges> bDateRangesTemp = new List<DateRanges>(bDateRanges);
        Console.WriteLine(Environment.NewLine + "+++++++++++++++++++++++++++++++++++++++++Recursion Level Id {0} +++++++++++++++++++++++++++++++++++++++++", recursionlevel);
        DisplayDateRanges(aDateRanges, " A Date Ranges ");
        DisplayDateRanges(bDateRanges, " B Date Ranges ");
        foreach (DateRanges br in bDateRanges)
        {
            if (br.StartDate == br.EndDate)
                return gapFill;
            foreach (DateRanges ar in aDateRanges)
            {
                if (ar.StartDate == ar.EndDate)
                    return gapFill;
                if (br.StartDate == ar.StartDate && br.EndDate == ar.EndDate)
                    continue;
                else if (br.StartDate >= ar.StartDate && br.EndDate <= ar.EndDate)
                {
                    gapFillTemp.AddRange(GetGaps(new List<DateRanges> { new DateRanges(ar.StartDate, br.StartDate) }, bDateRangesTemp, recursionlevel + 1));
                    if (gapFillTemp.Count == 0)
                    {
                        //gapFillTemp.Add(new DateRanges(ar.StartDate, br.StartDate));
                    }
                    bDateRangesTemp.AddRange(gapFillTemp);
                    gapFill.AddRange(gapFillTemp);
                    gapFillTemp.Clear();
                    gapFillTemp.AddRange(GetGaps(new List<DateRanges> { new DateRanges(br.EndDate, ar.EndDate) }, bDateRangesTemp, recursionlevel + 1));
                    if (gapFillTemp.Count == 0)
                    {
                       // gapFillTemp.Add(new DateRanges(br.EndDate, ar.EndDate));
                    }
                    bDateRangesTemp.AddRange(gapFillTemp);
                    gapFill.AddRange(gapFillTemp);
                    gapFillTemp.Clear();
                }
                else if (br.StartDate < ar.EndDate && br.EndDate >= ar.EndDate)
                {
                    gapFillTemp.AddRange(GetGaps(new List<DateRanges> { new DateRanges(ar.StartDate, br.StartDate) }, bDateRangesTemp, recursionlevel + 1));
                    if (gapFillTemp.Count == 0)
                    {
                        //gapFillTemp.Add(new DateRanges(ar.StartDate, br.StartDate));
                    }
                    bDateRangesTemp.AddRange(gapFillTemp);
                    gapFill.AddRange(gapFillTemp);
                    gapFillTemp.Clear();
                }
                else if (ar.StartDate >= br.StartDate && ar.StartDate < br.EndDate)
                {
                    gapFillTemp.AddRange(GetGaps(new List<DateRanges> { new DateRanges(br.EndDate, ar.EndDate) }, bDateRangesTemp, recursionlevel + 1));
                    if (gapFillTemp.Count == 0)
                    {
                       // gapFillTemp.Add(new DateRanges(br.EndDate, ar.EndDate));
                    }
                    bDateRangesTemp.AddRange(gapFillTemp);
                    gapFill.AddRange(gapFillTemp);
                    gapFillTemp.Clear();
                }
                else if (ar.StartDate >= br.StartDate && ar.EndDate <= br.EndDate)
                {
                    //     AS----AE
                    //  BS----------BE           
                    //Do Nothing
                }
                else
                {
                    if (AllowedToAdd(bDateRangesTemp, new DateRanges(ar.StartDate, ar.EndDate)))
                    {
                        bDateRangesTemp.Add(new DateRanges(ar.StartDate, ar.EndDate));
                        gapFill.Add(new DateRanges(ar.StartDate, ar.EndDate));
                    }
                }
            }
        }
        return gapFill;
    }
    static bool AllowedToAdd(List<DateRanges> bDateRanges, DateRanges newItem)
    {
        return !bDateRanges.Any(m =>
            (m.StartDate < newItem.StartDate &&
             newItem.StartDate < (m.EndDate))
            ||
            (m.StartDate < (newItem.EndDate) &&
             (newItem.EndDate) <= (m.EndDate))
            ||
            (newItem.StartDate < m.StartDate &&
             m.StartDate < (newItem.EndDate))
            ||
            (newItem.StartDate < (m.EndDate) &&
             (m.EndDate) <= (newItem.EndDate))
            );
    }
