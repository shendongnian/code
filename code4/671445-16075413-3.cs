    public ActionResult ListPeople()
    {
        var model = for p in db.Persons 
                    select new PersonAddViewModel {
                        Id = p.Id,
                        Name = p.Name,
                        Street = p.Address.Street,
                        // or if collection
                        Street2 = p.Addresses.Select(a => a.Street).FirstOrDefault()
                    }
        return View(model.ToList());
    }
