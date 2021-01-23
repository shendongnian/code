     [HttpPost]
    public ActionResult Index(LoginModels model)
    {
          Session["username"] = model.UserName;
         //remaining code
    }
