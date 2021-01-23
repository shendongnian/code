    public class GBDateModelBinder : IModelBinder
    
    	{
    
    		#region IModelBinder Members
    
    		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    		{
    			string dateString = controllerContext.HttpContext.Request.QueryString[bindingContext.ModelName];
    			 DateTime dt = new DateTime();
    			bool success = DateTime.TryParse(dateString, CultureInfo.GetCultureInfo("en-GB"), DateTimeStyles.None, out dt);
    			if (success)
    			{
    				return dt;
    			}
    			else
    				{
    				return null;
    			}
    		}
    
    		#endregion
    	}
