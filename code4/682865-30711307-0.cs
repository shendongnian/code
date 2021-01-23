         private void AddNewEmployee()
         {
            using (DataContext objDataContext = new DataContext())
            {                
                Employee objEmp = new Employee();
                // fields to be insert
                objEmp.EmployeeName = "John";
                objEmp.EmployeeAge = 21;
                objEmp.EmployeeDesc = "Designer";
                objEmp.EmployeeAddress = "Northampton";                
                objDataContext.Employees.InsertOnSubmit(objEmp);
                // executes the commands to implement the changes to the database
                objDataContext.SubmitChanges();
            }
          }
