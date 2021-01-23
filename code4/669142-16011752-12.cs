    [HttpGet] // this action result returns the partial containing the modal
    public ActionResult EditPerson(int id)
    {  
        var viewModel = new EditPersonViewModel();
        viewModel.Id = id;
        return PartialView("_EditPersonPartial", viewModel);
    }
    [HttpPost] // this action takes the viewModel from the modal
    public ActionResult EditPerson(EditPersonViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var toUpdate = personRepo.Find(viewModel.Id);
            toUpdate.Name = viewModel.Name;
            toUpdate.Age = viewModel.Age;
            personRepo.InsertOrUpdate(toUpdate);
            personRepo.Save();
            return View("Index");
        }
    }
