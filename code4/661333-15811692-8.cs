    [HttpGet]
    public ActionResult LoginRegister() {
         LoginRegisterViewModel model = new LoginRegisterViewModel();
         return view("LoginRegister", model);
    }
    [HttpPost]
    public ActionResult Login(LoginRegisterViewModel model) {
     //do your login code here
    }
    [HttpPost]
    public ActionResult Register(LoginRegisterViewModel model) {
     //do your registration code here
    }
