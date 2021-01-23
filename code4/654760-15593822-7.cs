    //recreate the compound viewmodel in the login controller
     Access viewModel = new Access();
     viewModel.LoginModel = model;
     viewModel.RegisterModel = new RegisterModel();
    return View("LoginOrRegister", viewModel); //supposing the view name is LoginOrRegister.cshtml
    //recreate the compound viewmodel in the register controller
     Access viewModel = new Access();
     viewModel.LoginModel = new LoginModel();
     viewModel.RegisterModel = model;
     return View("LoginOrRegister", viewModel); //supposing the view name is LoginOrRegister.cshtml
