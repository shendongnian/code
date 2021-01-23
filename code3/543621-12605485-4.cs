    public class Datasource : IEnumerable
    {
    	private DataTable _dt;
    
    	public Datasource(DataTable dt)
    	{
    		_dt = dt;
    	}
    
    	public IEnumerator GetEnumerator()
    	{
    		foreach (DataRow row in _dt.Rows)
    		{
    			IDictionary<string, object> obj = new ExpandoObject();
    			for (int i = 0; i < _dt.Columns.Count; i++)
    			{
    				var value = row[i];
    				if (value is byte[])
    					value = BitConverter.ToString((byte[])value);
    				obj[_dt.Columns[i].ColumnName] = value;
    			}
    			yield return obj;
    		}
    	}
    }
