    public class StudDataAccess
    {
        public string connectionString = "Data Source=USER\\SQLEXPRESS;Initial Catalog=db;Integrated Security=SSPI;";
        public int pStudId
        {
            set;
            get;
        }
        public string pStudName
        {
            set;
            get;
        } 
        public void NewStudent()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StudId", SqlDbType.Int).Value = pStudId;
            cmd.Parameters.Add("@StudName", SqlDbType.VarChar, 50).Value = pStudName;            
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            conn.Close();
        }  
    }
