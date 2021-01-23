        public void ProcessRequest(HttpContext context)
        {
            if (string.Compare(context.Request.QueryString["page"].ToString(), "1") == 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("1");
            }
            else if (string.Compare(context.Request.QueryString["page"].ToString(), "2") == 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("2");
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("rest");
            }
        }
