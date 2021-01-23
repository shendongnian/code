    public ActionResult Edit(int id, EditMViewModel m)
    {
        var someObject = LoadFromDb(id);
        if (ModelState.IsValid)
        {
            someObject.A = m.A;
            SaveToDb(someObject)
        }
        return RedirectToAction("Index");
    }
