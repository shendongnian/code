    public ActionResult Index()
    {
        string id = Request.QueryString["UserID"];
        IList<CartModel> objshop = new List<CartModel>();
        // assuming GetCartDetails returns an empty list & not null if there is nothing
        objshop = GetCartDetails(id);
        return View(objshop.ToList());
    }
