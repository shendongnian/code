    [HttpPost]
    public ActionResult Create(UserRegistrationViewData model)
    {
        if (ModelState.IsValid)
        {
            if (!someObject.IsRegistrationNumberValid(model.value))
            {
                ModelState.AddModelError("PropertyName", "There is an error..");
                Return View()
            }
            else
            {
                // Carry out successful action here...
            }
        }
    }
