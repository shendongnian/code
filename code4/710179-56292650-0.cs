	[HttpPost]
	public ActionResult NewUser(UserViewModel userVM)
	{
		User u = new User();
		u.Name = null;
		if (this.TryValidateObject(u))
		{
			TempData["NewUserCreated"] = "New user created sucessfully";
			return RedirectToAction("Index");
		}
		return View();
	}
