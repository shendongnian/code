       public ActionResult BlogEntry(int year, int month , int day , string title)
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
         using System.Web.Mvc;
        namespace OurAttributes
        {
         public class PopulateTitleDandDateAttribute : ActionFilterAttribute
         {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                    string[] url = filterContext.HttpContext.Request.Uri.split('/');
                    DateTime d = new Date(url[2],url[3],url[4]);
                    if (filterContext.ActionParameters.ContainsKey("createdDate"))
                    {
                        filterContext.ActionParameters["createdDate"] = d;
                    }
                    if (filterContext.ActionParameters.ContainsKey("title"))
                    {
                        filterContext.ActionParameters["title"] = url[5] ;
                    }
                    base.OnActionExecuting(filterContext);
                
            
        }
      }
     }
