    foreach (Dimension dimension in Enum.GetValues(typeof(Dimension)))
    {
        var r = new ReferenceTable(dimension).referenceItems;
        var qry = TVRawDataList.Where(p => !r.Any(d => dimension.IsAMatch(d.Value, p)))
                               .ToList();     
           
        DimensionItem di = new DimensionItem(qry, dimension);
        newDimensions.Add(di); 
     }
    bool IsAMatch<T>(this Dimension dimension, T valueToMatch, TVRawDataRecord obj)
    {
        return valueToMatch == GetProperty<T>(dimension.ToString(), p);
    }
    T GetProperty<T>(string propertyName, TVRawDataRecord obj, T dummyVariable)
    {
         var property = typeof(TVRawDataRecord).GetProperty(propertyName);
         if (property == null)
             return null; //or throw whatever
         return (T)property.GetValue(obj, null);
    }
