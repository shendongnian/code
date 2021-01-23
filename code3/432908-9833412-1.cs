    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(Employee employee)
    {
        if(ModelState.IsValid)
        {
            var persistentEmployee = repository.Get(employee.Id);
            if(  persistentEmployee == null){
                throw new Exception(String.Format("Employee with Id: {0} does not exist.", employee.Id));
            }
            persistentEmployee.Name = employee.Name;
            persistentEmployee.PhoneNumber = employee.PhoneNumber;
            //and so on
            repository.Update(persistentEmployee);
            return RedirectToAction("Deatils", "Employee", new { id = employee.ID });
        }
        else
        {
            return View(employee);
        }
    }
