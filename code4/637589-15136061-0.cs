    public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                // Bail if we can't do anything; app will crash.
                if (filterContext == null)
                    return;
                // since we're handling this, log to ELMAH(Error logging modules and handler)
                if (filterContext.Exception == null || filterContext.ExceptionHandled)
                {
                    var ex = filterContext.Exception ?? new Exception("No further information exists.");
                    this.WriteToEventLog(ex);
                    return;
                };
                filterContext.ExceptionHandled = true;
                var data = new ErrorPresentation
                {
                    ErrorMessage = HttpUtility.HtmlEncode(ex.Message),
                    TheException = ex,
                    ShowMessage = filterContext.Exception != null,
                    ShowLink = false
                };
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Home/ErrorPage.aspx"
                };
            }
            catch (Exception exception)
            {
                throw;
            }
        }
