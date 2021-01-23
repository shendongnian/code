    public HttpResponseMessage GetPdfPage()
        {
            HttpResponseMessage responce =  new HttpResponseMessage();
            string basePath = System.AppDomain.CurrentDomain.BaseDirectory;
            responce.Content = new StreamContent(new FileStream(HttpContext.Current.Server.MapPath(basePath +"somefile.pdf"), FileMode.Open, FileAccess.Read));
            responce.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    
            return responce;
        }
        
