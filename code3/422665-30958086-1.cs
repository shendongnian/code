    public ActionResult Index(string email){
        Session["stuff"]=Load(email);
        return RedirectToAction("View1action", new { email = email, color = "red" });
    }
    public ActionResult View1action(string email){
        return View("View1",(StuffClass)Session["stuff"]);
    }
