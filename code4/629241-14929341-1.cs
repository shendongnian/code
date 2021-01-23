    [HttpPost]
    public ActionResult Create(Person person)
    {
        if (ModelState.IsValid)
        {
            var context = new AppDbContext();
            context.People.Add(person);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(personViewModel);
    }
