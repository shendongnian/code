    [HttpPost]
    public HttpResponseMessage Picture([FromODataUri] int key)
    {
        var folderName = "App_Data/Koala.jpg";
        string path = System.Web.HttpContext.Current.Server.MapPath("~/" + folderName);
        StreamContent sc = new StreamContent(new FileStream(path,FileMode.OpenRead));
            HttpResponseMessage response = new HttpResponseMessage();                
            response.Content = sc;
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            response.StatusCode = HttpStatusCode.OK;
            return response;
    }
