    protected void Page_Load(object sender, EventArgs e)
    
            {
    
    
                string path = Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port + "/";
    
                myRedirect(path + "TestRedirectTo.aspx", "test", "testValue");
    
            }
    
            protected void myRedirect(string url, string headerName, string headerValue)
    
            {
    
                Response.Clear();
    
                System.Net.WebRequest request = System.Net.WebRequest.Create(url);
    
                request.Headers.Add(headerName, headerValue);
    
                System.Net.WebResponse response = request.GetResponse();
    
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);
    
    
                string content = sr.ReadToEnd();
    
                sr.Close();
    
                Response.Write(content);
    
                sr.Close();
    
                Response.End();
    
            }
