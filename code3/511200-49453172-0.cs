    public interface IEmployee
    {
        DateTime GetDateofJoining(int id);
    }
    public class Employee
    {
        public DateTime GetDateofJoining(int id)
        {
            return DateTime.Now;
        }
    }
        public class Program
    {
        static void Main(string[] args)
        {
            var employee = new Mock<IEmployee>();
            employee.Setup(x => x.GetDateofJoining(It.IsAny<int>())).Returns((int x) => DateTime.Now);
            Console.WriteLine(employee.Object.GetDateofJoining(1));
            Console.ReadLine();
        }
    }
