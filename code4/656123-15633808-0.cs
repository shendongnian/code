    public IQueryable<Record> GetRecordsForMonth(DateTime minDateInclusive.
                                                 DateTime maxDateExclusive)
    {
        return new RecordContext().Where(record => record.Date >= minDateInclusive
                                                && record.Date < maxDateExclusive);
    }
