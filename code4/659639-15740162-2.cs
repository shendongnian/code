    public ActionResult Login(EmployeeModel employeeModel)
    {
        var Errors = new List<string>();
        var employee = .... //Get employee from DB
        if (employee == null)
        {
            Errors.Add("Employee trouble");
            return PartialView("_ErrorPartial", Errors.AsEnumerable());
        }
        return Json(new { redirectUrl = Url.Action("Index", "Dashboard") });
    }
