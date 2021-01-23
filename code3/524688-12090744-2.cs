    public T GetVariableValue<T>(TaxReturn taxReturnObj, string identityKey)
    		{
    			if (taxReturnObj.Identity.ContainsKey(identityKey))
    			{
    				if(typeof(T) == Int32)
    				{	  
    					int returnTypeOut = 0;
    					int.TryParse(taxReturnObj.Identity[identityKey], out returnTypeOut);
    					return returnTypeOut;
    				}
    				else if (typeof(T) == System.String)
    				{
    				//code here
    				}
    			}
    			return default(T);
    		}
