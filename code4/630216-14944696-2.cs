    private bool Validate(Object viewModel)
    {
       var castViewModel = (RegisterModel)viewModel;
       if(ModelState.IsValid)
       {
          ...
       }
    }
