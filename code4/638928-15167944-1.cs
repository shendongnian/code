    public async Task<ActionResult> Index()
    {
        ViewBag.Message = await (Session["Stuff"] as Task<int>);
        return View();
    }
