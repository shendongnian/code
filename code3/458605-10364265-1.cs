    public static T CreateObjectFromRow<T>(DataRow row)
    {
    	var newObject = new T();
    
    	if (row != null) SetAllProperties(row, newObject);
    
    	return newObject;
    }
    public static void SetAllProperties<T>(DataRow row, T newObject)
    {
    	var properties = typeof(T).GetProperties();
    
    	foreach(var propertyInfo in properties)
    	{
    		SetPropertyValue(row, newObject, propertyInfo);
    	}
    }
    public static void SetPropertyValue(DataRow row, T newObject, PropertyInfo propertyInfo)
    {
    	var columnAttribute = propertyInfo.FindAttribute<SqlMetaAttribute>();
    
    	if (columnAttribute == null) return;
    
    	// If the row type is different than the object type and exception will be thrown, but that is
    	// okay because if that happens you have to fix your object you are using, or might need some
    	// more custom code to help you with that.
    	propertyInfo.SetValue(newObject, row.GetValue<object>(columnAttribute.ColumnName), null);
    }
    // Extension method for row.GetValue<object> used above
    public static T GetValue<T>(this DataRow row, string columnName)
    {
    	if (row.ColumnNameNotFound(columnName) || row.Table.Columns[columnName] == null || row[columnName] is DBNull)
    	{
    		return default(T);
    	}
    
    	return (T)row[columnName];
    }
