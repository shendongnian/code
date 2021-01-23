    public IEnumerable<Record> SearchRecord()
    {
        var records = db.Records;
        if (Name != null)
        {
            records = records.Where(r => r.Name == Name);
        }
        if (Date != null)
        {
            records = records.Where(r => r.Date == Date);
        }
        if (Country != null)
        {
            records = records.Where(r => r.Country == Country);
        }
        return records;
    }
