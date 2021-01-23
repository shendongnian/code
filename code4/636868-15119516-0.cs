    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult add()
    {
        ...
    }
    
    [ActionName("add")]
    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult add_post()
    {
        ...
    }
