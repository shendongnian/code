    public class StudentDAL : DALBase
    {
        public DataSet GetAllStudents()
        {
            DataSet ds = null;
            
            //query to ask
            string query = "SELECT * FROM Student";
            using (OleDbCommand command = new OleDbCommand(query))
            {
                ds = Fill(command);            
            }   
            return ds;     
        }
        
        public void UpdateStudentName(int studentID, string name)
        {            
            string query = "UPDATE Student SET Name = @Name WHERE StudentID = @StudentID";
            using (OleDbCommand command = new OleDbCommand(query))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@StudentID", studentID);
                
                ExecuteNonQuery(command);            
            }        
        }
    }
