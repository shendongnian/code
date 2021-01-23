    public class Student
    {
        public string StudentName { get; set; }
        public int Age { get; set; }
    }
    
    public class School : Student
    {
        public string SchoolName { get; set; }
    }
    
---
    
    List<School> school = new List<School>();
    school.Add(new School() { SchoolName = "USA", StudentName = "har", Age = 25 });
    school.Add(new School() { SchoolName = "USM", StudentName = "japz", Age = 25 });
    foreach (var item in school)
    {
        Console.WriteLine("School Name: {0} Name: {1} Age: {2} ", item.SchoolName, item.StudentName, item.Age);
    }
