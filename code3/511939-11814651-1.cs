            private void Application_EndRequest(Object source, EventArgs e) 
            {
                HttpApplication application = (HttpApplication)source;
                HttpContext context = application.Context;
                context.Response.ExpiresAbsolute = DateTime.Now.AddDays( -100 );
                context.Response.AddHeader( “pragma”, “no-cache” );
                context.Response.AddHeader( “cache-control”, “private” );
                context.Response.CacheControl = “no-cache”;
            }
