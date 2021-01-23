    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(int id, FormCollection formValues)
    {
    	HashTable hash = repository.GetHashTable(id);
    	UpdateModel(hash);
    	repository.Save();
    	return RedirectToAction("Details", new { id = hash.DinnerID });
    } 
