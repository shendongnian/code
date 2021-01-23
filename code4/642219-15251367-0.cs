    public class Student : Person
    {
        public Student(Person person, string code) : base(person.FName, person.LName)
        {
            this.code = code;
        }
        public string code { get; set; }
    }
    public class Person
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public Person(string fname, string lname)
        {
            FName = fname;
            LName = lname;
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Paul", "Catch");
            Student student = new Student(person, "1234");
            Console.WriteLine(student.code);
        }
    }
