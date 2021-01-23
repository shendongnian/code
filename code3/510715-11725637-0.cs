    namespace ConsoleApplication12
    {
        public class Employee
        {
            public string EmpName { get; set; }
    
            public override string ToString()
            {
                return this.EmpName;
            }
        }
    
        public class Student
        {
            public string StudName { get; set; }
    
            public override string ToString()
            {
                return this.StudName;
            }
        }
    
        public class Other
        {
            public int TestField { get; set; }
    
            public override string ToString()
            {
                return this.TestField.ToString();
            }
        }
    
        public interface IRepository<T>
        {
            List<T> GetAll();
        }
    
        public class PersonRepository : IRepository<Employee>, IRepository<Student>, IRepository<Other>
        {
            List<Student> IRepository<Student>.GetAll()
            {
                return new List<Student> { new Student { StudName = "test2" } };
            }
    
            List<Other> IRepository<Other>.GetAll()
            {
                return new List<Other> { new Other { TestField = 42 } };
            }
    
            List<Employee> IRepository<Employee>.GetAll()
            {
                return new List<Employee> { new Employee { EmpName = "test1" } };
            }
        }
    
        public class Program
        {
            private static void Main(string[] args)
            {
                PersonRepository d = new PersonRepository();
    
                // Returns "test1"
                Console.WriteLine(((IRepository<Employee>)d).GetAll()[0]);
    
                // Returns "test2"
                Console.WriteLine(((IRepository<Student>)d).GetAll()[0]);
    
                // Returns 42
                Console.WriteLine(((IRepository<Other>)d).GetAll()[0]);
    
                Console.ReadLine();
            }
        }
    }
