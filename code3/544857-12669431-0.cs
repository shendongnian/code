    protected void Page_Load(object sender, EventArgs e)
    {
        string proxyURL = HttpUtility.UrlDecode(Request.QueryString["u"]);
    
        if (proxyURL != string.Empty)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(proxyURL);
            request.Method = "GET";
            request.ContentLength = 0;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
    
            if (response.StatusCode.ToString().ToLower() == "ok")
            {
                string contentType = response.ContentType;
                Stream content = response.GetResponseStream();
                if (content != null)
                {
                    StreamReader contentReader = new StreamReader(content);
                    Response.ContentType = contentType;
                    Response.Write(contentReader.ReadToEnd());
                }
            }
        }
    }
