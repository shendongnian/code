    public class StudentInfo
    {
    public string Type { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    ...
    }
    
    
    var students = stud.Student_A.Where(...).Select(a => new StudentInfo { Type = "Student_A", FirstName = a.FirstName, LastName = a.LastName });
    
    students.concat( stud.Student_B.Where(...).Select(b => new StudentInfo { Type = "Student_B", FirstName = b.FirstName, LastName = b.LastName });
    
    ViewData.Model = students;
    
    return View();
