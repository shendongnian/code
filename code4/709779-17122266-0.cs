    var tasks = new Dictionary<string, string>();
    var selectCmd = "SELECT UserTaskId, Name FROM UserTasks";
    using (SqlConnection c = new SqlConnection(connString))
    {
        c.Open();
        using (SqlCommand cmd = new SqlCommand(selectCmd, c))
        {
            // provide any parameters
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                tasks.Add(rdr.GetString(0), rdr.GetString(1));
            }
        }
    }
