    public Expression<Func<DocumentEntry, int, bool>> CreateWhereClause(stuff);
    public IList<DocumentEntry> GetDocumentEntriesForRateAdjustmentTry2(
    string username, Rate rate, List<RatePeriod> ratePeriods)
    {
        using(var db = new Context())
        {
            IQueryable<DocumentEntry> foo = db.Foos;
            foreach(var i =0; i <4; i++)
            {
                foo = foo.Where(DocumentEntry(i));
            }
        }
    }
