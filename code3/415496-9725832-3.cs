    object fxClass = myAssembly.CreateInstance(cls.FullName);
    Type t = fxClass.GetType();
        
        
    var arrRates = Array.CreateInstance(t, tab.Rows.Count);
    int i =0;
    foreach (DataRow dr in tab.Rows)
    {
        fxClass = myAssembly.CreateInstance(cls.FullName);
        PropertyInfo[] fxRateProperties = t.GetProperties();
        foreach (PropertyInfo prop in fxRateProperties)
        {
            string rowVal = dr[prop.Name].ToString();
        
            if (prop.PropertyType == typeof(DateTime))
            {
                prop.SetValue(fxClass, util.convertToDate(rowVal), null);
            }
            else if (prop.PropertyType == typeof(bool))
            {
                prop.SetValue(fxClass, util.convertToBoolean(rowVal), null);
            }
            else if (prop.PropertyType == typeof(decimal))
            {
                prop.SetValue(fxClass, util.convertToDecimal(rowVal), null);
            }
            else prop.SetValue(fxClass, rowVal, null);                                           
        }
        arrRates.SetValue(fxClass,i);
        i++;
    }
    myClass.GetType().GetProperty("ForexRates").SetValue(myClass, arrRates, null);
