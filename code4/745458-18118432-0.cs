    public class DBStudentService:IStudentService{
    
        public Dictionary<int, int> GetStudentData()
        {
        // Key: Student ID Value: Total marks(marks in math + marks in physics)
            Dictionary<int, int> studentResultDict = new Dictionary<int, int>();
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=myDB;Integrated Security=true"))
                {
                    con.Open();
                    string cmdStr = "Select * from Student";
                    using (SqlCommand cmd = new SqlCommand(cmdStr, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                studentResultDict.Add((int)reader["ID"], (int)reader["MarksInMath"] + (int)reader["MarksInPhysics"]);
                            }
                        }
                    }
                }
    
                return studentResultDict;
            }
    }
