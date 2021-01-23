    public class MyService : IAutofacActionFilter
        {
            private UrlHelper _urlHelper;
    
            public void DoSomething()
            {
                var link = Url.Link("SomeRoute", new {});
            }
    
            private UrlHelper Url
            {
                get
                {
                    if(_urlHelper == null)
                        throw new InvalidOperationException();
    
                    return _urlHelper;
                }
            }
    
            public void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext actionExecutedContext)
            {            
            }
    
            public void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
            {
                this._urlHelper = actionContext.Request.GetUrlHelper();
            }
        }
