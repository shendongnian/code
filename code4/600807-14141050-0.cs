    public ActionResult Index(string id)
    {
          var url = Db.GetNeededUrl(id);
          return Redirect(url);
    }
