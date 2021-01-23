    public ActionResult ChangeDBPostAndRedirectToExternal(string parameter1, string parameter2)
    {
        DoSomeDatabaseStuff();    
        ViewBag.PostViaJs = String.Format("post_to_url('{0}','{1}', '{2}');", externalUrl, parameter1, parameter2);
    }
