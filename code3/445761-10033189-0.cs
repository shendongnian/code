    using System.Linq;
    ...
    void Main()
    {
    	var students = GetStudentCollection();
    	Console.WriteLine(students);
    }
    
    public class Student
    {
    	public string StudentID { get; set; }
    	public string FirstName { get; set; }
    	public string LastName { get; set; }
    
    }
    
    public Student[] ListStudents()
    {
       List<Student> student = new List<Student>()
       {
    	   new Student { StudentID="bla", FirstName="bla", LastName="bla"},
    	   new Student { StudentID="bla1", FirstName="bla1", LastName="bla1"},
    	   new Student { StudentID="bla2", FirstName="bla2", LastName="bla2"}
       };
    	return student.ToArray();
    }
    
    public List<Student> GetStudentCollection()
    {
    	return ListStudents().ToList(); //<-- this is the change you need
    }
