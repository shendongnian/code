    [OperationContract]
    StudentDTO GetStudent(int studentId);
    [OperationContract]
    StudentDTO UpdateStudent(CreateStudentDTO student);
    [OperationContract]
    StudentDTO UpdateStudent(UpdateStudentDTO student);
    [DataContract]
    public class StudentDTO
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public StudentInformationDTO StudentInformation { get; set; }
    
      // other student's data here
    }
