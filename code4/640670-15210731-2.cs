    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace MvcApplication1.Controllers
    {
    	public static class CustomHtmlHelpers
    	{
    		public static MvcHtmlString ActionLink(this HtmlHelper htmlHelper, string linkText,	string routePath)
    		{
                //you can do any sort of logic you want here.
    			return MvcHtmlString.Create(string.Format("<a href=\"{0}\">{1}<a/>", routePath, linkText));
    		}
    	}
    }
