    class Program
    {
        string SchoolName,
               EnrollmentStatus,
               ColorOne,
               ColorTwo;
    public static void GetSchoolInfo()
    {
        Console.WriteLine("Please enter your school name: ");
        SchoolName = Console.ReadLine();
        Console.WriteLine("Please enter your Enrollment Status: ");
        EnrollmentStatus = Console.ReadLine();
        Console.WriteLine("Pleas enter one of your school's colors: ");
        ColorOne = Console.ReadLine();
        Console.WriteLine("Please enter the other school color: ");
        ColorTwo = Console.ReadLine();
    }
    static void Main(string[] args)
    {
        GetSchoolInfo();
        Console.ReadLine();
    }
