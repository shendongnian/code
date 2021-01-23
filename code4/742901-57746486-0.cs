    public ActionResult Edit(int? EmployeeId)
            {
                EmployeeContext employeeContext = new EmployeeContext();
                Employee employee = employeeContext.Employees.Where(emp => emp.EmployeeId == EmployeeId).First();
                return View(employee);
            }
