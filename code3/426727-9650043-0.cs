    // Common DAL DataContext field.
    DataContext Context = new DataContext();
    
    public IEnumerable<Record> GetRecords()
    {
        var records = Context.Records;
    
        foreach (var record in records)
        {
            yield return record;
        }    
    }
    
    public void UpdateData()
    {
        Context.SaveChanges();
    }
