    var url=string.Format("{0}?id={1}",Request.UrlReferrer,id);
    return new RedirectResult(url);
     public ActionResult Index(string id, int? page)
        {
            //some code
        }
