    public ActionResult Index()
    {
                Session["InitialLoad"] = "Yes";
                VMHome h = new VMHome();
                h.heatSearch = "";
                h.MissingQueryResults = new SelectList(H.MissingQueryResults())
                return View(h);
    } 
    [HttpPost]
    public ActionResult Index(VMHome model)
    {
                //do something with your posted data
                // may be adding search result to the viewmodel
                return View(model);
    }
 
