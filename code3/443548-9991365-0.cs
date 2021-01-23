    public ActionResult Index()
    {
        var context = new PetaPoco.Database("DataContext");
        return View(context.Query<BiddersViewModel>("exec udsp_Bidders_SelectAll"));
    }
