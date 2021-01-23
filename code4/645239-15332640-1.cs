    public class HomeController
    {
        private IStudent _student;
        public HomeController(IStudent student)
        {
            _student = student;
        }
    }
    public interface IStudent
    {
        // Some method
    }
    public class Student : IStudent
    {
        // Implementation of some method
    }
