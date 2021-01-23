        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Do Not Allow URL to end in trailing slash
            string url = HttpContext.Current.Request.Url.AbsolutePath;
            if (string.IsNullOrEmpty(url)) return;
            string lastChar = url[url.Length-1].ToString();
            if (lastChar == "/" || lastChar == "\\")
            {
                url = url.Substring(0, url.Length - 1);
                Response.Clear();
                Response.Status = "301 Moved Permanently";
                Response.AddHeader("Location", url);
                Response.End();
            }
        }
