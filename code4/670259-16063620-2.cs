        public void ProcessRequest(HttpContext context)
        {
            //write your handler implementation here.
            //Http
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            //Header - Properites
            int Index = -1;
            string[] Keys = request.Headers.AllKeys;
            List<string[]> Values = new List<string[]>();
            //Header - Loop to get key values
            for (int i = 0; i < Keys.Length; i++)
            {
                Values.Add(request.Headers.GetValues(i));
                //Check if property "Accept" exists
                if (Keys[i].CompareTo("Accept") == 0)
                    Index = i;
            }
            //Check if URL and URL Referrer are null
            if (context.Request.Url != null && context.Request.UrlReferrer != null && Index >= 0)
            {
                //Check image types
                if (!context.Request.UrlReferrer.AbsolutePath.EndsWith(".bmp") ||
                    !context.Request.UrlReferrer.AbsolutePath.EndsWith(".jpg") ||
                    !context.Request.UrlReferrer.AbsolutePath.EndsWith(".jpeg") ||
                    !context.Request.UrlReferrer.AbsolutePath.EndsWith(".png"))
                {
                    //Check header "Accept"
                    if (Values[Index][0].CompareTo("*/*") == 0)
                    {
                        //Get bytes from file
                        byte[] MyBytes = File.ReadAllBytes(context.Request.PhysicalPath);
                        //new HttpContext(context.Request, context.Response).Request.MapPath(context.Request.RawUrl).ToString()
                        context.Response.OutputStream.Write(MyBytes, 0, MyBytes.Length);
                        context.Response.Flush();
                    }
                    else
                        //Redirect                
                        context.Response.Redirect("/Home");
                }
                else
                    //Redirect                
                    context.Response.Redirect("/Home");
            }
            else
                //Redirect                
                context.Response.Redirect("/Home");
        }
