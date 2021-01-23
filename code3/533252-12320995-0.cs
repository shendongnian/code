		[HttpPost]
		public ActionResult Create(User user)
		{
			if (TryValidateModel(user))
			{
				// creation code here
				return RedirectToAction("Index");
			}
			else
			{
				return View(user);
			}
		}
