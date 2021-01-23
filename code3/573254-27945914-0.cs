    public static IList&lt;T&gt; DatatableToClass&lt;T&gt;(DataTable Table) where T : class, new()
    {
    	if (!Helper.IsValidDatatable(Table))
    		return new List&lt;T&gt;();
    
    	Type classType = typeof(T);
    	IList&lt;PropertyInfo&gt; propertyList = classType.GetProperties();
    
    	// Parameter class has no public properties.
    	if (propertyList.Count == 0)
    		return new List&lt;T&gt;();
    
    	List&lt;string&gt; columnNames = Table.Columns.Cast&lt;DataColumn&gt;().Select(column =&gt; column.ColumnName).ToList();
    
    	List&lt;T&gt; result = new List&lt;T&gt;();
    	try
    	{
    		foreach (DataRow row in Table.Rows)
    		{
    			T classObject = new T();
    			foreach (PropertyInfo property in propertyList)
    			{
    				if (property != null && property.CanWrite)	 // Make sure property isn't read only
    				{
    					if (columnNames.Contains(property.Name))  // If property is a column name
    					{
    						if (row[property.Name] != System.DBNull.Value)	 // Don't copy over DBNull
    						{
    							object propertyValue = System.Convert.ChangeType(
    									row[property.Name],
    									property.PropertyType
    								);
    							property.SetValue(classObject, propertyValue, null);
    						}
    					}
    				}
    			}
    			result.Add(classObject);
    		}
    		return result;
    	}
    	catch
    	{
    		return new List&lt;T&gt;();
    	}
    }
