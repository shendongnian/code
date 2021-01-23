    public class SomeClassBLL
    {
        private _someClassDAL = new someClassDAL();
        
        public DataSet GetAllStudents()
        {        
            return _someClassDAL.GetAllStudents();                    
        }
        
        public void UpdateStudentName(Student student)
        {        
            _someClassDAL.UpdateStudentName(student.StudentID, student.Name);                    
        }
    }
