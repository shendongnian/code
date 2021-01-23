    string selectTopics = "select count(*) from topics";
    // Define the ADO.NET Objects
    using (SqlConnection con = new SqlConnection(connectionString))
    {
       SqlCommand topiccmd = new SqlCommand(selectTopics, con);
       con.Open();
       int numrows = (int)topiccmd.ExecuteScalar();
       if (numrows == 0)
        {
            noTopics.Visible = true;
            topics.Visible = false;
        }
    }
