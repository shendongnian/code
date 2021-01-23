	[HttpPost]
	public ActionResult Update(MemberUpdateModel model)
	{
		if (!ModelState.IsValid)
		{
			model.SetStateSelectList(_db, model.SelectedStateId);
			return View(model);
		}
		var newModel = new MemberUpdateModel();
		newModel.Member = _db.Members.Include("Address").FirstOrDefault(q => q.Id == model.Member.Id);
		newModel.Member.Address.State = _db.States.FirstOrDefault(q => q.Id == model.SelectedStateId);
		bool success = TryUpdateModel(newModel);
		if (success)
		{
			_db.SaveChanges();
		}
		else
		{
			throw new Exception("TryUpdateModel() Failed");
		}
		return RedirectToAction("Index");
	}
