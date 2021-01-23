    public List<T> ToList<T>(this DataTable dt)
    {
    	List<T> res = new List<T>();
    	try {
    		if (dt != null && dt.Rows.Count > 0) {
    			object prps = typeof(T).GetProperties;
    			object prpnames = prps.Select((System.Object f) => f.Name).ToList;
    			for (i = 0; i <= dt.Rows.Count - 1; i++) {
    				T Tinst = Activator.CreateInstance(typeof(T));
    				for (j = 0; j <= dt.Columns.Count - 1; j++) {
    					int prpInd = prpnames.IndexOf(dt.Columns(j).ColumnName);
    					if (prpInd >= 0) {
    						prps(prpInd).SetValue(Tinst, dt(i)(j), null);
    					}
    				}
    				res.Add(Tinst);
    			}
    		}
    	} catch (Exception ex) {
    		PromptMsg(ex);
    	}
    	return res;
    }
