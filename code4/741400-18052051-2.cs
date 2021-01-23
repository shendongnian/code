    private static List<EmployeeDetails> empdtls;
        public ActionResult PostValues()
        {
            return View();
        }
    [HttpPost]
    public ActionResult PostValues(EmployeeDetails model)
    {
        ViewBag.item = model.EnteredValue;
        ParentViewModel viewmodels = new ParentViewModel
        {
            TextBoxGrid = new TextBoxGrid { employees = GetEmployee().ToList() }
        };
        ParentViewModel viewmodel = new ParentViewModel();
        EmployeeDetails em1 = new EmployeeDetails();
        for (int i = 0; i < viewmodels.TextBoxGrid.employees.Count(); i++)
        {
            em1.EmployeeId = viewmodels.TextBoxGrid.employees[i].EmployeeId;
            em1.ManagerId = viewmodels.TextBoxGrid.employees[i].ManagerId;
            viewmodel.EmployeeDetails = em1;
        }
        Session["EM1"] = em1;
        return View("PostValues", em1);
    }
    public List<EmployeeDetails> GetEmployee()
    {
        string enteredValueId = (string)ViewBag.item;
        string managerId = "M" + enteredValueId;
        empdtls = new List<EmployeeDetails>();
        EmployeeDetails em1 = new EmployeeDetails();
        em1.EmployeeId = enteredValueId;
        em1.ManagerId = managerId;
        if (Session["EM1"] != null)
        {
            em1 = Session["EM1"] as EmployeeDetails;
            empdtls.Add(em1);
            Session["EM1"] = null;
        }
        else
        {
            empdtls.Add(em1);
        }
        return empdtls;
    }
    public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request, EmployeeDetails model)
    {
        return Json(GetEmployee().ToDataSourceResult(request));
    }
