       [HttpPost]
       public ActionResult DisplayEmployee(Guid id)
       {
        model.emp=GetEmployeeDetails(id);
         return View("GetEmployees");
       }
