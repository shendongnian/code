    public class ElmahHandler : ErrorLogPageFactory, IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var handler = InvokeMethod("FindHandler", requestContext.RouteData.Values["pathInfo"]) as IHttpHandler;
            if (handler == null)
                throw new HttpException(404, "Resource not found.");
            var num = (int)InvokeMethod("IsAuthorized", context);
            if (num != 0 && (num >= 0 || HttpRequestSecurity.IsLocal(context.Request) /*|| SecurityConfiguration.Default.AllowRemoteAccess*/))
            {
                return handler;
            }
            //new ManifestResourceHandler("RemoteAccessError.htm", "text/html").ProcessRequest(context);
            HttpResponse response = context.Response;
            response.Status = "403 Forbidden";
            response.End();
            return null;
        }
    }
