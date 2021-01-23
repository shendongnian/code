    using System.Collections.Specialized;
    using System.Web.Mvc;
    
    namespace Lil_Timmys_Example.Helpers
    {
    	public class NameValueAwareModelBinder : DefaultModelBinder
    	{
    		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    		{
    			if (bindingContext.ModelMetadata.ModelType == typeof(NameValueCollection))
    			{
    				var result = new NameValueCollection();
    
    				string prefix = bindingContext.ModelName + ".";
    
    				var queryString = controllerContext.HttpContext.Request.QueryString;
    				foreach (var key in queryString.AllKeys)
    				{
    					if (key.StartsWith(prefix))
    					{
    						result[key.Substring(prefix.Length)] = queryString.Get(key);
    					}
    				}
    
    				var form = controllerContext.HttpContext.Request.Form;
    				foreach (var key in form.AllKeys)
    				{
    					if (key.StartsWith(prefix))
    					{
    						result[key.Substring(prefix.Length)] = form.Get(key);
    					}
    				}
    
    				return result;
    			}
    			else
    			{
    				return base.BindModel(controllerContext, bindingContext);
    			}
    		}
    	}
    }
