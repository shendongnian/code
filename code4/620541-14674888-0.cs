     public void Start()
     {
         List<Employee> empLists = GetEmpData();  // geting lots of employee objects
         StartlongRunning(empLists);
     }
