    public static class DataTableEx
    {
    	public static IList<T> CreateList<T>(this DataTable dt,
    	    	    	    	    	     Func<DataRow,T> selector)
    	{
    		return dt.Rows.Cast<DataRow>().Select(selector).ToList();
    	}
    }
