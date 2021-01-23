    public class Student
    {
        //...
    }
                
                
    public class Class
    {
        //...
    }
                
    // New Map Class
    public class StudentClassMapRecord
    {
        public int Id; // Map record PK
        public Student Student { get; set; }
        public Class Class { get; set; }
    
        public StudentClassMapRecord(Student aStudent, Class aClass)
        {
            Student = aStudent;
            Class = aClass;
        }
    
        //Uncomment below if you don't need property navigation
        //public int StudentId { get; set; }
        //public int ClassId { get; set; }        
        //public StudentClassMapRecord(int studentId, int classId)
        //{
        //    StudentId = studentId;
        //    ClassId = classId;
        //} 
    }
