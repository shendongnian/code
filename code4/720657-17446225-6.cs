    DataSet newData;
    DataSet existingData;
    var before = existingData.AsEnumerable().ToDictionary(
        n => Guid.Parse(n.Field<string>("ID")),
        n => n);
    var after = newData.AsEnumerable().ToDictionary(
        n => Guid.Parse(n.Field<string>("ID")),
        n => n);
