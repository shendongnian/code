    [WebInvoke(Method = "GET", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml, UriTemplate = "picture/{width}/{height}")]
    Stream GetImage(string width, string height)
    {
        int w, h;
        if (!Int32.TryParse(width, out w))
        {
            // Handle error: use default values
            w = 640;
        }
        if (!Int32.TryParse(height, out h))
        {
            // Handle error use default values
            h = 480;
        }
        ....
    }
