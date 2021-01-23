    [HttpGet]
    public ActionResult Edit(int id)
    {
        var personVm = _dataSource.People.Single(p => p.PersonId == id)
            .Select(e => new PersonEditViewModel {
                        e.PersonId = p.PersonId,
                        e.Name = p.Name,
                        e.Website = p.Website
                        ...
                    });
        return View(personVm);
    }
    [HttpPost]
    public ActionResult Edit(PersonEditViewModel model)
    {
        if (ModelState.IsValid)
        {
            var person = _dataSource.People.Single(p => p.PersonId == model.PersonId);
            person.Name = model.Name;
            person.Website = model.Website;
            ...
            _dataSource.SavePerson(person);
            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }
