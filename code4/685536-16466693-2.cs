    public class SomeClassDAL : DALBase
    {
        public void GetAllStudents()
        {
            DataSet ds = null;
            
            //query to ask
            string query = "SELECT * FROM Student";
            using (OleDbCommand command = new OleDbCommand(query))
            {
                ds = Fill(command);            
            }        
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
