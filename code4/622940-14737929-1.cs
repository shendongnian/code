    public IEnumerable<ColumnEntity> GetColumnDomain<TColumn>(string column)
    {
        var query = db.CITATIONs
            .Select(GenerateSelector<CITATION, TColumn>(column))
            .Distinct();
        // ...
    }
