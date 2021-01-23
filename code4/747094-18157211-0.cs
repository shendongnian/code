    // Also often called Upsert short for "Update or Insert"
    public int Save(EmpObj employeeObj) 
    {
         if(CheckIfEmployeeExists(employeeObj))
         {
             return Update(employeeObj); // returns rows affected
         }
         else
         {
             return Insert(employeeObj); // Returns new Id of the employee.
         }
    }
    // Other methods, where the select, update and insert statements lies 
    or gets called    and build
    public bool CheckIfEmployeeExists(employeeObj) // Check If Employee Exists
    public int Update(employeeObj); // Updates the employee
    public int Insert(employeeObj); // Inserts the employee
