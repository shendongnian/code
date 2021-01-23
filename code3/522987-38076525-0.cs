    `public interface IEmployee
    {
        // define your model here (properties, for example)
        string FirstName {get; set;}
        string LastName {get; set;}
    }
    public interface IEmployeeBizFactory
    {
        IEmployee CreateEmployee();
    }
    public class CustomEmployee : IEmployee
    {
        // Implementation here
    }
    public class CustomEmployeeBizFactory : IEmployeeBizFactory
    {
        public IEmployee CreateEmployee()
        {
            return new CustomEmployee();
        }
    }`
