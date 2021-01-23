    public class RawDataService : IReceiveData
    {
        public List<Student> ListStudents()
        {
           List<Student> students = new List<Student>()
           {
               new Student { StudentID="bla", FirstName="bla", LastName="bla"},
               new Student { StudentID="bla1", FirstName="bla1", LastName="bla1"},
               new Student { StudentID="bla2", FirstName="bla2", LastName="bla2"}
           };
            return students;
        }
    
        public List<Student> GetStudentCollection()
        {
            return ListStudents(); //error on this line, cant convert array to list
        }
