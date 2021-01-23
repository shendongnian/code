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
    			return MvcHtmlString.Create(string.Format("<a href=\"someStaticPath{0}\">{1}<a/>", routePath, linkText));
    		}
    	}
    }
