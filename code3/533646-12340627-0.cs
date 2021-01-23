    public bool OnBeforeResourceLoad(IWebBrowser browser, 
        IRequestResponse requestResponse)
    {
        IRequest request = requestResponse.Request;
        if (request.Url.EndsWith(".gif")) {
            MemoryStream stream = new System.IO.MemoryStream();
            Properties.Resources.FooImage.Save(
                stream, System.Drawing.Imaging.ImageFormat.Bmp);
            requestResponse.RespondWith(stream, "image/gif");
        }
        else {
            Stream resourceStream = new MemoryStream(Encoding.UTF8.GetBytes(
                "<html><body><img src=\"foo.gif\" /></body></html>"));
            requestResponse.RespondWith(resourceStream, "text/html");
        }
        return false;
    }
