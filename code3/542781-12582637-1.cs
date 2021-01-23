    [HttpPost]
    public ActionResult MyAction(MyModel model)
    {
        //Do stuff.
        
        UriBuilder uriBuilder = new UriBuilder(Request.UrlReferrer);
        NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query.Add("myparam", "something");
        uriBuilder.Query = query.ToString();
        
        return new RedirectResult(uriBuilder.Uri);
    }
