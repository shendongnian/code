    public class Employee
    {
        public Employee(EmployeeCreationParams creationParams, EmployeeAccessList accessList)
        {
            this.Company = creationParams.Company;
            this.User = creationCommand.User;
            this.Access = accessList
        }
    }
    
    public class Repository
    {
        public void Persist<TEntity>(TEntity entity)
        {
            // encapsulate the fact that ACLs are stored in a separate way than Employees
        }
    }
