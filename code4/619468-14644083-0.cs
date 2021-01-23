    public ActionResult Index()
    {          
        var user = Session["User"];
        using (var db = new YourEntity())
        {
            var data = from u in db.EmployeeTabs.Where(p => p.EmpName == user).Select(v => v.Designation);
             if (data == null)
             {
                  return RedirectToAction("Register");
             }
             Switch(data.First().Designation)
             {
                 case "Receptionist":
                     return RedirectToAction(Register);
             }
       }
       return View();
    }
    public public ActionResult Register()
    {
        return View();
}       
   
