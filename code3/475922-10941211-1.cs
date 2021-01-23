    public static IsCurrent Func<IQueryable<PersonHistory>, DateTime, IQueryable<PersonHistory>>()
    {
        return (IQueryable<PersonHistory> query, DateTime referenceDate) =>
            query.Where(p.Ends > referenceDate && p.Starts <= referenceDate);
    }
