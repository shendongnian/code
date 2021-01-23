    [HttpPost]
    public ActionResult Index()
    {
        Flickr.CacheDisabled = true;
        string secret = "sss";
        string apikey = "abc";
        Flickr myFlickr = new Flickr(apikey, secret);
        var flickrFrob = myFlickr.AuthGetFrob();
        string url = myFlickr.AuthCalcUrl(flickrFrob, AuthLevel.Write);
        Response.Redirect(url);
    }
