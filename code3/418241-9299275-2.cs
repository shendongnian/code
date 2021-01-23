    IEnumerable<Department> departments = (from DataRow dRow in distrows   
                             new Department
            {
                DepartmentID = Int32.Parse(row["DepartmentID"].ToString()),
                Employee = new Employee { EmployeeName = row["EmployeeName"].ToString() }
            });
