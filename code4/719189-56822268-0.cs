    public static string ToJson(this DataTable dt)
    {
    	List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
    	Dictionary<string, object> item;
    	foreach (DataRow row in dt.Rows)
    	{
            	item = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                    	item.Add(col.ColumnName, (Convert.IsDBNull(row[col]) ? null : row[col]));		
    		}
    		lst.Add(item);
    	}
            return Newtonsoft.Json.JsonConvert.SerializeObject(lst);
    }
