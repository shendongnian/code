    Items.Add(VaryHttpModule.Key, "User-Agent");
    if (condition) 
    {
        Server.Transfer(redirectUrl);
    }
    else
    {
        Response.Redirect(redirectUrl);
    }
    public class VaryHttpModule : IHttpModule
    {
        public const string Key = "Vary";
        public void Init(HttpApplication context)
        {
            context.PostRequestHandlerExecute +=
                (sender, args) =>
                    {
                        HttpContext httpContext = ((HttpApplication)sender).Context;
                        IDictionary items = httpContext.Items;
                        if (!items.Contains(Key))
                        {
                            return;
                        }
                        object vary = items[Key];
                        if (vary == null)
                        {
                            return;
                        }
                        httpContext.Response.Headers.Add("Vary", vary.ToString());
                    };
        }
        public void Dispose()
        {
        }
    }
