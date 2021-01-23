    public FileContentResult DownloadCSV()
    {
        string csv = string.Concat(from employee in db.Employees
                                   select employee.EmployeeCode + "," 
                                   + employee.EmployeeName + "," 
                                   + employee.Department + "," 
                                   + employee.Supervisor + "\n");
        return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "Report.csv");
    }
