    public ActionResult PersonList()
    {
        ViewBag.Message = "My List";
        var list = db.Person
            .Select(p => new vm_PersonList
                         {
                             Person = p,
                             age = 23,
                         })
            .ToList();
 
        return View(list);
    }
