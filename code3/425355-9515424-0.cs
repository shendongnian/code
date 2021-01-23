    public IEnumerable<Stuff> GetStuffs(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new ArgumentException("startDate must be before endDate", "startDate");
        IDateRange dateRange = new DateRange(startDate, endDate);
        IDateRange[] dateRanges = _dateRangeSplitter.DivideRange(dateRange, TimeSpan.FromDays(1)).ToArray();
        IEnumerable<Stuff>[] resultCollections = new IEnumerable<Stuff>[dateRanges.Length];
        _parallel.For(0, dateRanges.Length, i =>
        {
            IDateRange splitRange = dateRanges[i];
            IEnumerable<Stuff> stuffs = GetMarketStuffs(splitRange);
            resultCollections[i] = stuffs;
        });
        Stuff[] marketStuffs = resultCollections.SelectMany(ef => ef).Distinct(ef => ef.EventId).ToArray();
        return marketStuffs;
    }
    private IEnumerable<Stuff> GetMarketStuffs(IDateRange splitRange)
    {
        IList<Stuff> stuffs = new List<Stuff>();
        HashSet<int> uniqueStuffIds = new HashSet<int>();
        string marketStuffString = _slowStuffStringProvider.GetMarketStuffs(splitRange.Start, splitRange.End);
        IEnumerable<ParsedStuff> rows = _stuffParser.ParseStuffString(marketStuffString);
        foreach (ParsedStuff parsedStuff in rows)
        {
            if (!uniqueStuffIds.Add(parsedStuff.EventId))
            {
                continue;
            }
            stuffs.Add(new Stuff(parsedStuff));
        }
        return stuffs;
    }
