    public List<ServiceStudent> GetAllStudents()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StudentCon"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from Student";
            cmd.Connection = con;
            con.Open();
            SqlDataReader studentReader = cmd.ExecuteReader();
            //Fill List of ServiceStudent from reader...
            con.Close();
       }
