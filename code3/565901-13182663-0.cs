	public ActionResult UniqueUsername(string userName, int id)
	{
		FinanceDataContext _db = new FinanceDataContext();
		var user = _db.Users.ToList().SingleOrDefault(x => x.Username.ToLower() == value.ToString().ToLower() && x.ID != id);
		return Json(user == null, JsonRequestBehavior.AllowGet);
	}
