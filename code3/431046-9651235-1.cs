    public class Student
    {
        public Student()
        {
           this.SetName();
           this.SetNumber();
           this.SetCourse()
           this.SetYear();
        }
    
        public override string ToString()
        {
            return string.Format(
                       "Name: {0}{4}Number: {1}{4}Course: {2}{4}Year: {3}{4}",
                        this.Name,
                        this.Number,
                        this.Course,
                        this.Year,
                        Environment.NewLine);
        }
    
        public void DisplayDetails()
        {
            Console.WriteLine(this.ToString());
        }
    
        public string Name { get; private set; }
        public string Number{ get; private set; }
        public string Course { get; private set; }
        public string Year { get; private set; }
    
        public static void SetName()
        {
          Console.WriteLine("Please enter Name: ");
          this.Name = Console.ReadLine();
        }
    
        public static void SetNumber()
        {
          Console.WriteLine("Please enter Number: ");
          this.Number = int.Parse(Console.ReadLine());
        }
    
        public static void SetCourse()
        {
          Console.WriteLine("Please enter Course: ");
          this.Course = Console.ReadLine();
        }
    
        public static void SetYear()
        {
          Console.WriteLine("Please enter Year: ");
          this.Year = int.Parse(Console.ReadLine());
        }
    }
    
    public class App
    {
        public static void Main()
        {
           Student student1 = new Student(); // Create a student
           student1.DisplayDetails(); // show the details 
           student1.SetName(); // change the name
           student1.SetYear(); // change the year
           student1.DisplayDetails(); // show the new details 
           // etc...
        }
    }
