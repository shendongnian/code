    public class StudentBLL
    {
        private _studentDAL = new StudentDAL();
        
        public DataSet GetAllStudents()
        {        
            return _studentDAL.GetAllStudents();                    
        }
        
        public void UpdateStudentName(Student student)
        {        
            _studentDAL.UpdateStudentName(student.StudentID, student.Name);                    
        }
    }
