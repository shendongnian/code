    public interface IDataOperation
    {
        List<Employee> GetEmployees();
    }
    public class DataOperation : IDataOperation
    {
        public List<Employee> GetEmployees(){}
    }
