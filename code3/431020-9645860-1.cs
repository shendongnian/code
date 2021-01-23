    public List<T> ExecuteQuery<T>(string s, SqlConnection condb, params SqlParameter[] Params)
    {
    	List<T> res = new List<T>();
    	string er = "";
    	SqlDataReader r = null;
    	try {
    		if (condb == null)
    			throw new Exception("Connection is NULL");
    		if (string.IsNullOrEmpty(s))
    			throw new Exception("The query string is empty");
    		using (SqlCommand cm = new SqlCommand(s, condb)) {
    			if (Params.Length > 0) {
    				cm.Parameters.AddRange(Params);
    			}
    			if (cm.Connection.State != ConnectionState.Open)
    				cm.Connection.Open();
    			r = cm.ExecuteReader;
    
    			object prps = typeof(T).GetProperties;
    			object prpNames = prps.Select((System.Object f) => f.Name).ToList;
    
    			if (r.HasRows) {
    				while (r.Read) {
    					if (typeof(T).FullName.Contains("System.")) {
    						res.Add(r(0));
    					// Classes
    					} else {
    						object c = Activator.CreateInstance(typeof(T));
    						for (j = 0; j <= r.FieldCount - 1; j++) {
    							object jj = j;
    							//er = dt.Rows(jj)("ColumnName").ToLower
    							object fname = r.GetName(j).ToString;
    							er = fname;
    							object fType = r.GetProviderSpecificFieldType(j).ToString.ToLower;
    							object p = prps.Where((System.Object f) => f.Name.Trim.ToLower == fname.ToLower).ToList;
    							if (p.Count > 0) {
    								//Date or DateTime
    								if (fType.Contains("date")) {
    									if (!p(0).PropertyType.FullName.ToLower.Contains("system.nullable") && (r(fname) == null || r(fname).Equals(System.DBNull.Value))) {
    										p(0).SetValue(c, Now, null);
    									} else {
    										if (!(p(0).PropertyType.FullName.ToLower.Contains("system.nullable") && (r(fname) == null || r(fname).Equals(System.DBNull.Value)))) {
    											p(0).SetValue(c, r(fname), null);
    										}
    									}
    								//String
    								} else if (fType.Contains("string")) {
    									if (r(fname) == null || r(fname).Equals(System.DBNull.Value)) {
    										p(0).SetValue(c, "", null);
    									} else {
    										p(0).SetValue(c, r(fname), null);
    									}
    								} else {
    									if (!(p(0).PropertyType.FullName.ToLower.Contains("system.nullable") && (r(fname) == null || r(fname).Equals(System.DBNull.Value)))) {
    										p(0).SetValue(c, r(fname), null);
    									}
    								}
    							}
    						}
    						res.Add(c);
    					}
    				}
    			}
    			r.Close();
    
    		}
    	//If cm IsNot Nothing Then
    	//    'cm.Connection.Close()
    	//    cm.Dispose()
    	//End If
    
    	} catch (Exception ex) {
    		if (r != null && r.IsClosed == false)
    			r.Close();
    		throw ex;
    	}
    	return res;
            }
 
