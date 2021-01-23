    string selectSQL = @"SELECT * FROM tbl_lecturer_project;
                         SELECT * FROM tbl_student_project_choice;
                         SELECT * FROM tbl_team";
    using(SqlConnection con = new SqlConnection(connectionString))
    {
       con.Open();
       using(SqlCommand cmd = new SqlCommand(selectSQL, con))
       {
          using(SqlDataAdapter adapter = new SqlDataAdapter(cmd))
          {
             DataSet dsPubs = new DataSet();
             adapter.Fill(dsPubs);
             // use dataset.
          }
       }
    }
