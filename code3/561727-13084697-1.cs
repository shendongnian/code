        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string image = "main";
            if (context.Session != null && context.Session["agency"] != null)
            {
                image = context.Session["agency"].ToString();
            }
            string result = ".main{padding: 0px 12px; margin: 0px 0px 0px 0px; min-height: 630px; width:auto; background-image:url('" + image + ".png');}";
            context.Response.Write(result);
        }
