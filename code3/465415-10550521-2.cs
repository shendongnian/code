    public ActionResult Edit(int id)
    {
         // Get the required application
         GrantApplication application = grantApplicationService.FindById(id);
    
         // Mapping
         MyViewModel viewModel = (MyViewModel)
              grantApplicationMapper.Map(
              application,
              typeof(GrantApplication),
              typeof(MyViewModel)
         );
    
         // BankId comes from my table.  This is the unique identifier for the bank that was selected when the application was added
    
         // Get all the banks
         viewModel.Banks = bankService.FindAll().Where(x => x.IsActive);
         return View(viewModel);
    }
