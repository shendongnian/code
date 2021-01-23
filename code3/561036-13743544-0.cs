    List<Employee> emp;
    // Run when program starts, called from Program.cs
    private void InitialiseApplication()
    {
        emp = new List<Employee>;
         
        // Gather data for employees from... somewhere.
        DataAccess.GetEmployees(emp);
    }
    private void DoStuff()
    {
        foreach (var item in emp)
        {
             // Do something.
        }
    }
