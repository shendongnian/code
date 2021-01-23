    public class PersonRepository : IPersonRepository
    {
        // yada yada yada
    
        public void Add(Person person)
        {
            Uow.Persons.Add(person);
        }
    
        public void Update(Person person)
        {
            Uow.Persons.Attach(person);
            Uow.Entry(person).State = EntityState.Modified;
        }
    }
    
    [HttpPost]
    public ActionResult Edit(Person person)
    {
        if (ModelState.IsValid)
        {
            _personRepository.Update(person);
            _personRepository.Uow.Commit();
    
            return RedirectToAction("Index");
        }
    
        return View(person);
    }
