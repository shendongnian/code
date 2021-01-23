    public ActionResult Test()
    {
      var Person = db.GetPerson();
      PersonSession.Current = Person;
      this.View();
    }
    [HttpPost]
    public ActionResult Test(Person)
    {
      if (Person.FirstName != PersonSession.Current.FirstName)
      {
        // etc, etc 
        PersonSession.Clear();
      }
    }
