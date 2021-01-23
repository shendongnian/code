    public ActionResult Register(){
        Access viewModel = new Access();
        viewModel.LoginModel = new LoginModel();
        viewModel.RegisterModel = new RegisterModel();
        return View("LoginOrRegister",viewModel);
    } 
