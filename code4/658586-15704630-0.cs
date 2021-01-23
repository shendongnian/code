    Connection db = new Connection();
    public ActionResult Index()
    {
        ViewBag.types = from input in db.field
                        where input.ID_FIELD == 1
                        select input.FIELD_TYPE;
        return View();
    }
