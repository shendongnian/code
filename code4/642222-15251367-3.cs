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
    public class Student : Person
    {
        public Student(Person person, string code)
            : base(person.FName, person.LName)
        {
            this.code = code;
        }
        public Student(Person person)
            : base(person.FName, person.LName)
        {
            
        }
        public string code { get; set; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Paul", "Catch");
            // create new student from person using 
            Student student = new Student(person, "1234"); 
            //or
            Student student1 = new Student(person);
            student1.code = "5678";
            Console.WriteLine(student.code); // = 1234
            Console.WriteLine(student1.code); // = 5678
        }
    }
