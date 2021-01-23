    [HttpPost]
    public ActionResult Index(PackagemODEL packageModel, FormCollection form)
    {
        packageModel.Allcategories = new IEnumerable<SelectListItem>();
    }
