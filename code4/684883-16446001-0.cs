    public ActionResult BannerAds()
    {
        string idStr = Request.QueryString.ToString().Trim('='); // strip of leading '='
        int id;
        if (!int.TryParse(idStr, out id))
        {
            return HttpNotFound();
        }
        ...
    }
