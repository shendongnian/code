    [HttpPost]
    public ActionResult Create(UserModel user)
    {
        Debug.Assert(data != null);
        return Json(data);
    }
