    // Method called from kendo grid
    public virtual ActionResult Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ExpandoObject> createdRecords) 
    {
        Type originalGridType = GetTypeOfModelUsingCustomCodeIDevelopedEarlier();
        foreach (ExpandoObject record in createdRecords)
        {
            var convertedType = Impromptu.InvokeConvert(record, originalGridType);
            T objectInstance = Impromptu.ActLike(convertedType);
            objectInstance.Save();
        }
    }
