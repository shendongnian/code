    public T GetVariableValue<T>(TaxReturn taxReturnObj, string identityKey)
        	{
        		if (taxReturnObj.Identity.ContainsKey(identityKey))
        		{
        			if(typeof(T) == Int32)
        			{
        				return Convert.ToInt32(taxReturnObj.Identity[identityKey]);
        			}
        			else if (typeof(T) == System.String)
        			{
        			//code here
        			}
        		}
        	}
