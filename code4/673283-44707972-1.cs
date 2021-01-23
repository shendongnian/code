    /// <summary>
    /// map properties
    /// </summary>
    /// <param name="sourceObj"></param>
    /// <param name="targetObj"></param>
    private void MapProp(object sourceObj, object targetObj)
    {
        Type T1 = sourceObj.GetType();
        Type T2 = targetObj.GetType();
        PropertyInfo[] sourceProprties = T1.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        PropertyInfo[] targetProprties = T2.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            
       foreach (var sourceProp in sourceProprties)
       {
           object osourceVal = sourceProp.GetValue(sourceObj, null);
           int entIndex = Array.IndexOf(targetProprties, sourceProp);
           if (entIndex >= 0)
           {
               var targetProp = targetProprties[entIndex];
               targetProp.SetValue(targetObj, osourceVal);
           }
       }
    }
