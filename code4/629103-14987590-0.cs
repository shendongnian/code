    //
    // POST: /BusinessManager/ManageCompanies/Add
    [HttpPost]
    public ActionResult Add(AddCompanyViewModel addCompanyViewModel)
    {
        if (ModelState.IsValid)
        {
            // Create company and attempt to register the user
            try
            {
                WebSecurity.CreateUserAndAccount(addCompanyViewModel.User.UserName,
                                                    addCompanyViewModel.User.Password,
                                                    propertyValues: new
                                                    {
                                                        FirstName = addCompanyViewModel.User.FirstName,
                                                        LastName = addCompanyViewModel.User.LastName,
                                                        EmailAddress = addCompanyViewModel.User.EmailAddress,
                                                        PhoneNumber = addCompanyViewModel.User.PhoneNumber,
                                                        MarketingEmailOptin = addCompanyViewModel.User.MarketingEmailOptin,
                                                        isDisabled = false
                                                    });
                db.Companies.Add(addCompanyViewModel.Company);
                    
                var newuser = db.UserProfiles.FirstOrDefault(u => u.UserName == addCompanyViewModel.User.UserName);
                if (newuser != null)
                {
                    newuser.CompanyICanEdit = addCompanyViewModel.Company;
                    db.Entry(newuser).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "New user wasn't added");
                }                     
            }
            catch (MembershipCreateUserException e)
            {
                ModelState.AddModelError("", Mywebsite.Controllers.AccountController.ErrorCodeToString(e.StatusCode));
            }
                
        }
        return View(addCompanyViewModel);
    }
