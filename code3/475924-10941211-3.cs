    public static IsCurrent Func<IQueryable<PersonHistory>, IQueryable<PersonHistory>>(
        DateTime referenceDate)
    {
        return (IQueryable<PersonHistory> query) =>
            query.Where(p.Ends > referenceDate && p.Starts <= referenceDate);
    }
    var query = IsCurrent(refernceDate);
    var results = query(context.PeoplesHistory);
