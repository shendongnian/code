    Image image;
    WebRequest request = WebRequest.Create("http://<insert URL here >");
    using (WebResponse response = request.GetResponse())
    {
        using (Stream stream = response.GetResponseStream())
        {
            image = Image.FromStream(stream);
        }
    }
    // Use image here...
