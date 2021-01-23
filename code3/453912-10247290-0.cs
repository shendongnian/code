        protected void Application_Error() { 
            HttpContext ctx = HttpContext.Current; 
            var error = ctx.Server.GetLastError();
            ctx.Response.Clear(); 
            ctx.Response.End(); 
        }
