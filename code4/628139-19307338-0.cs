    namespace CompanyName.Models.Platform.Exceptions
    {
    	/// <summary>
    	/// Custom SQL Elmah logger with more details from the Exception.Data Collection
    	/// </summary>
    	public class EnhancedSqlErrorLog : SqlErrorLog
    	{
    		public EnhancedSqlErrorLog(IDictionary config) : base(config)
    		{
    			// Must define for Elmah to work
    		}
    
    		public EnhancedSqlErrorLog(string connectString) : base(connectString)
    		{
    			// Must define for Elmah to work
    		}
    
    		public override string Log(Error error)
    		{
    			// If there is data on the exception, log it
    			if (error.Exception.Data != null && error.Exception.Data.Keys.Count > 0)
    			{
    				var sb = new StringBuilder();
    
    				foreach (var key in error.Exception.Data.Keys)
    				{
    					sb.AppendLine(key + " - " + error.Exception.Data[key]);
    				}
    
    				// Be sure to append to whatever is already there
    				error.Detail += sb.ToString();
    			}
    
    			return base.Log(error);
    		}
    	}
    }
