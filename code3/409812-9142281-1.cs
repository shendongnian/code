    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.Routing;
    using System.Web.UI;
    namespace SampleWeb.Utility.Handlers
    {
        public class DefaultRouteHandeler:IRouteHandler
        {
            public IHttpHandler GetHttpHandler(RequestContext requestContext)
            {
                //Url mapping however you want here: 
                string routeURL = requestContext.RouteData.Values["url"] as string ;
                string pageUrl = "~/" + (!String.IsNullOrEmpty(routeURL)? routeURL:""); 
                var page = BuildManager.CreateInstanceFromVirtualPath(pageUrl, typeof(Page))
                           as IHttpHandler;
                if (page != null)
                {
                    //Set the <form>'s postback url to the route 
                    var webForm = page as Page;
                    if (webForm != null)
                        webForm.Load += delegate
                        {
                            webForm.Form.Action =
                            requestContext.HttpContext.Request.RawUrl;
                        };
                }
                return page;
            }
        }
    }
