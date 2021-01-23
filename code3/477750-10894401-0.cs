    HttpWebRequest WebRequest = HttpWebRequest.CreateHttp(uri);
    WebRequest.BeginGetResponse((asyncCallback) =>
    {
        try
        {            
            MediaLibrary library = new MediaLibrary();
            library.SavePicture(imageName, WebRequest.EndGetResponse(asyncCallback).GetResponseStream());
        }
        catch (Exception e) { }
    }, WebRequest);
