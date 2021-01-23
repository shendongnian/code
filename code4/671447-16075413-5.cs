    public ActionResult ListPeople()
    {
        var model = (from p in db.Persons // .Includes("Addresses") here?
                    select new PersonAddViewModel() {
                        Id = p.Id,
                        Name = p.Name,
                        Street = p.Address.Street,
                        // or if collection
                        Street2 = p.Addresses.Select(a => a.Street).FirstOrDefault()
                    });
        return View(model.ToList());
    }
