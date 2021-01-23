    public ActionResult ContactList()
    {
        var partyId = (int)Session["PartyId"];
        var viewModel = _displayBuilder.Build(partyId);
        return PartialView("_ContactList", viewModel);
    }
    [HttpGet]
    public ActionResult AddContact()
    {
        var partyId = (int) Session["PartyId"];
        var viewModel = _createBuilder.Build(partyId);
        return PartialView("_AddContact", viewModel);
    }
    [HttpPost]
    public ActionResult AddContact(AddContactViewModel viewModel)
    {
        var partyId = (int) Session["PartyId"];
        if (ModelState.IsValid)
        {
            _contactsManager.AddContact(viewModel, partyId);
            if (Request.IsAjaxRequest())
                return Json(new { passedValidation = true, action = Url.Action("ContactList")});
            return RedirectToAction("Index");
        }
            
        var newViewModel = _createBuilder.Rebuild(viewModel, partyId);
        return PartialView("_AddContact", newViewModel);
    }
