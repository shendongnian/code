     protected void Application_BeginRequest(object sender, EventArgs e)
        {
             Don't rewrite requests for content (.png, .css) or scripts (.js)
            if (Request.Url.AbsolutePath.Contains("/Content/") ||
                Request.Url.AbsolutePath.Contains("/Scripts/"))
                return;
            If uppercase chars exist, redirect to a lowercase version
            var url = Request.Url.ToString();
           if (Regex.IsMatch(url, @"[A-Z]"))
            {
                Response.Clear();
               Response.Status = "301 Moved Permanently";
               Response.StatusCode = (int)HttpStatusCode.MovedPermanently;
                Response.AddHeader("Location", url.ToLower());
                Response.End();
           }
        }
