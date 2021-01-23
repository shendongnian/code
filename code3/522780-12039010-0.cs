    public class WebService1 : System.Web.Services.WebService
    {
        public class Course
        {
            public string Name { get; set; }
        }
        public class Student
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public List<Course> CurrentCourses { get; set; }
        }
        [WebMethod]
        public Student HelloWorld()
        {
            Student Baxter = new Student();
            
            Baxter.Name = "Baxter";
            Baxter.BirthDate = new DateTime(1986, 04, 22);
            Baxter.CurrentCourses = new List<Course>();
            Baxter.CurrentCourses.Add(new Course() { Name = "SOAP Webservices 101" });
            Baxter.CurrentCourses.Add(new Course() { Name = "Mastering C#" });
            Baxter.CurrentCourses.Add(new Course() { Name = "Why you (and I) suck at Javascript" });
            return Baxter;
        }
    }
