    public class SchoolInfo
    {
        /* two properties are defined as public to carry the data */
        public string NameOfTheSchool { get; set; }
        public string AddressOfTheAchool { get; set; }
    }
    
    
    class Program
    {
        public static void GetSchoolInfo(SchoolInfo info)
        {
            info.NameOfTheSchool = "AA";
            info.AddressOfTheAchool = "BB";
        }
        
        static void Main()
        {
            // create the instance of the class
            SchoolInfo mySchoolInfo = new SchoolInfo();
            // pass it into GetSchoolInfo to collect the data
            GetSchoolInfo(mySchoolInfo);
            // print the value of the name of the school
            Console.WriteLine(mySchoolInfo.NameOfTheSchool);
            Console.ReadKey();
        }
    }
