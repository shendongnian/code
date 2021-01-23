        public ActionResult CreateEmployee(EmployeeModel emp)
        {
             //Add Employee to db
             ViewBag.employee=emp;
             RedirectToAction("MethodToCall","Controller");
        }
