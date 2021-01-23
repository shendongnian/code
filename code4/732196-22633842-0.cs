    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TWV.Infrastructure;
    using TWV.Models;
    namespace TWV.Controllers
    {
        public class TerminateOnAbortAttribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // IE does not always terminate when ajax request has been aborted - however, the input stream gets wiped
                // The content length - stays the same, and thus we can determine if the request has been aborted
                long contentLength = filterContext.HttpContext.Request.ContentLength;
                long inputLength = filterContext.HttpContext.Request.InputStream.Length;
                bool isAborted = contentLength > 0 && inputLength == 0;
                if (isAborted)
                {
                    filterContext.Result = new EmptyResult();
                }
            }
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                // Do nothing
            }
        }
    }
