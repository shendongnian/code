    public IEnumerable<Record> SearchRecord()
    {
        var records = db.Records.Where(r => (Name == null || r.Name == Name)
                                            && (Date == null || r.Date == Date)
                                            && (Country == null || r.Country == Country));
        return records;
    }
