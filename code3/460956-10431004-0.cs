    public class EmployeeService : IEmployeeService
    {
          private readonly static EmployeeService _instance = new EmployeeService();
          public static EmployeeService Instance
          {
              get { return _instance; }
          }
    }
