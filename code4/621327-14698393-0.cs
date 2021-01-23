            public class SchoolInfo
            {
                public string SchoolName { get; set; }
                public string EnrollmentStatus { get; set; }
                public string ColorOne { get; set; }
                public string ColorTwo { get; set; }
            }
    
            public static SchoolInfo GetSchoolInfo()
            {
                string SchoolName,
                       EnrollmentStatus,
                       ColorOne,
                       ColorTwo;
    
                Console.WriteLine("Please enter your school name: ");
                SchoolName = Console.ReadLine();
                Console.WriteLine("Please enter your Enrollment Status: ");
                EnrollmentStatus = Console.ReadLine();
                Console.WriteLine("Pleas enter one of your school's colors: ");
                ColorOne = Console.ReadLine();
                Console.WriteLine("Please enter the other school color: ");
                ColorTwo = Console.ReadLine();
    
                return new SchoolInfo()
                    {
                        SchoolName = SchoolName,
                        EnrollmentStatus = EnrollmentStatus,
                        ColorOne = ColorOne,
                        ColorTwo = ColorTwo
                    };
            }
    
    
            private static void Main(string[] args)
            {
                SchoolInfo info = GetSchoolInfo();
                Console.WriteLine("You Entered School Name: "+info.SchoolName);
                Console.ReadLine();
    
            }
