        public class SomeService
    {
        public void SomeeMethod()
        {
         int employeeId = 10; // for example
         EmployeeRepository repository = new EmployeeRepository();
         Employee employee = repository.GetById(employeeId);
         repository.Delete(employee);
         //...
        }
        }
