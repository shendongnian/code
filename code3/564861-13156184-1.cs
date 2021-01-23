    [XmlElement]
    public class StudentDTO 
    {
    	[XmlElement]
    	public string StudentName {get;set;}
    }
    
    [XmlElement]
    public class StudentsDTO : List<StudentDTO> 
    {
    }
    
    public class Student
    {
    	public string Name {get;set;}
    }
    
    //Ideally on big System, Mapper class would be a generic on the lines of Mapper<Source,Target>
    //Mapper<StudentDTO,Student> and based on some rules it would do mapping.
    public class StudentDTOToStudentMapper
    {
    	public Student GetStudentForDTO(StudentDTO dto)
    	{
    		//create object of student
    		// Map corresponding property of StudentDTO to Student
    		// e.g. StudentName to Name
    	}
    }
    
    public class Client
    {
    	public static void Main(DBHelper dbHandler, XMLSerialiser seriliaser, WebService serviceToCall,StudentDTOToStudentMapper mapper )
    	{
    		// XmlDocument/Object obj = serviceToCall.GetStudentsXML();
    		// StudentsDTO students = Seriliaser.Deserialise(XML);
    		// IEnumerable<Student> studentObjects = from eachDTO in students 
    		//				  	 select mapper.GetStudentForDTO(eachDTO)
    		// bool IsSaved = dbHandler.Save(students);
    		// Based on IsSaved show the status.
    	}	
    }
