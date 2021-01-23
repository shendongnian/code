        public void ProcessRequest(HttpContext context)
        {
            //Http
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            //Header
            string[] Keys = request.Headers.AllKeys;
            List<string[]> Values = new List<string[]>();
            for (int i = 0; i < Keys.Length; i++)
            {
                Values.Add(request.Headers.GetValues(i));
            }
            //Check if URL and URL Referrer are null
            if (context.Request.Url != null && context.Request.UrlReferrer != null)
            {
                //Check image types
                if (!context.Request.UrlReferrer.AbsolutePath.EndsWith(".bmp") ||
                    !context.Request.UrlReferrer.AbsolutePath.EndsWith(".jpg") ||
                    !context.Request.UrlReferrer.AbsolutePath.EndsWith(".jpeg") ||
                    !context.Request.UrlReferrer.AbsolutePath.EndsWith(".png"))
                {
                    //Check header "Accept"
                    if (Values[1][0].CompareTo("*/*") == 0)
                    {
                        //Get Bytes
                        byte[] MyBytes = File.ReadAllBytes(context.Request.PhysicalPath);
                        //new HttpContext(context.Request, context.Response).Request.MapPath(context.Request.RawUrl).ToString()
                        context.Response.OutputStream.Write(MyBytes, 0, MyBytes.Length);
                        context.Response.Flush();
                    }
                }
            }
            //Redirect                
            context.Response.Redirect("/Home");
        }
