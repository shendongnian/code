    public IEnumerable<Record> SearchRecord()
    {
        var records = db.Records.Where(r => r.Name == (Name ?? r.Name)
                                            && r.Date == (Date ?? r.Date)
                                            && r.Country == (Country ?? r.Country));
        return records;
    }
