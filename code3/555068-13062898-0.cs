    public void Init(HttpApplication context)
            {
                context.BeginRequest += new EventHandler(context_BeginRequest);
            }
    
            public void context_BeginRequest(Object source, EventArgs e)
            {
                //Code to reject the HTTP requests on basis of Config Value
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
    
                if (context != null)
                {
                    if (Utilities.Utility.HttpsCheck)
                    {
                        if (!context.Request.IsSecureConnection)
                        {
                            context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                            context.Response.StatusDescription = "Secure connetion required";
                            context.Response.End();
                        }
                    }
                }
            }
