    public ActionResult DemoInsert(EmployeeModel emp)
    {
        Employee emptbl = new Employee();// make object of table
        emptbl.EmpName = emp.EmpName;
        emptbl.EmpAddress = emp.EmpAddress;
        //add if any field you want insert
        dbc.Employees.Add(emptbl);pass the table object 
        dbc.SaveChanges();
        return View();
    }
      
