    public ActionResult UserForm(UserFormViewModel vm)
    {
        string username = vm.Username;
        int age = vm.Age;
        
        // persist to database, etc
        return View();
    }
