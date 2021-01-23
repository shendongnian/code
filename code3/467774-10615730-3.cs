    var Obj = new Analysis();
    Type t = Obj.GetType();
    PropertyInfo[] prop = t.GetProperties();
    foreach (var pi in prop.Where(p => p.PropertyType == typeof(int)) 
    {
        int min = _valuesForExtraCalculations.Min(c => (int)pi.GetValue(c, null));
        propertyInfo.SetValue(Obj, min, null);
    }
