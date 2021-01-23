    public ActionResult TestPost()
    {
        return View();
    } 
    [HttpPost]
    public ActionResult TestPost(TestPost post)
    {
        return View(post);
    } 
