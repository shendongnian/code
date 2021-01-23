     [HttpGet]
                public ActionResult Edit(int id)
                {
                    EmployeeContext employeeContext = new EmployeeContext();
                    Employee employee = employeeContext.Employees.Where(emp => emp.EmployeeId == id).First();
                    return View(employee);
                }
