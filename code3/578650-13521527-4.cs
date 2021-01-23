    foreach (Dimension dimension in Enum.GetValues(typeof(Dimension)))
    {
        var r = new ReferenceTable(dimension).referenceItems;
        var qry = TVRawDataList.Where(p => !r.Any(d => IsAMatch(p, dimension, d.Value)))
                               .ToList();     
           
        DimensionItem di = new DimensionItem(qry, dimension);
        newDimensions.Add(di); 
    }
    bool IsAMatch<T>(TVRawDataRecord obj, Dimension dimension, T valueToMatch)
    {
        return valueToMatch == dimension.MapToTvRecordProperty<T>(obj);
    }
    T MapToTvRecordProperty<T>(this Dimension dimension, TVRawDataRecord obj)
    {
        return obj.GetPropertyValue<T>(dimension.ToString());
    }
    T GetPropertyValue<T>(this TVRawDataRecord obj, string propertyName)
    {
         var property = typeof(TVRawDataRecord).GetProperty(propertyName);
         if (property == null)
             return null; //or throw whatever
         return (T)property.GetValue(obj, null);
    }
