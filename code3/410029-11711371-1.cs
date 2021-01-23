    public ActionResult Authenticated(string frob)
    {
        Flickr.CacheDisabled = true;
        string secret = "sss";
        string apikey = "abc";
        Flickr flickr = new Flickr(apikey, secret);
        Auth auth = flickr.AuthGetToken(frob);
        ViewData.Add("frob", frob);
        return View();
    }
