    string selectTopics = "select count(*) from topics";
    // Define the ADO.NET Objects
    SqlConnection con = new SqlConnection(connectionString);
    SqlCommand topiccmd = new SqlCommand(selectTopics, con);
    con.open()
    int numrows = (int)topiccmd.ExecuteScalar()
    if (topiccmd == 0)
        {
            noTopics.Visible = true;
            topics.Visible = false;
        }
