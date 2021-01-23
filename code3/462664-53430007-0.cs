    public List<string> GetClientImagePath()
    		{
    			//return objDAL.GetClientImagePath();
    			List<string> clientimagepath = new List<string>();
    			DataSet ds = new DataSet();
    
    			try
    			{
    				ds = objDAL.GetClientImagePath();
    				if (ds.Tables.Count > 0)
    				{
    					ds.Tables[0].TableName = "clientimagepath";
    					clientimagepath = (from DataRow dr in ds.Tables["clientimagepath"].Rows
    									   select Convert.ToString(dr["ImagePath"])
    										).ToList();
    				}
    			}
    			catch (Exception ex)
    			{
    				throw ex;
    			}
    			return clientimagepath;
    		}
