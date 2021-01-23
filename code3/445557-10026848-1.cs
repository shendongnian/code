    public ActionResult ShowGrid(int personId)
    {
        var person = SomeKindOfDatabaseAccess.GetPerson(personId);
        var viewModel = new MyViewModel(person);
        return View(viewModel);
    }
