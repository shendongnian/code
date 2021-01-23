        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SPMS_DBConnectionString1"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        using (SqlCommand command = connection.CreateCommand())
        { 
            DateTime startDate = DateFromMiliSec(start);
            DateTime dueDate = DateFromMiliSec(end);
            int progress = Convert.ToInt32(prog);
            string prID = HttpContext.Current.Session["project"].ToString();         
            command.CommandText ="UPDATE Project SET startDate = @startDate, dueDate = @dueDate, progress = @progress, status = @status WHERE (prID = @prID)";
            command.Parameters.AddWithValue("@startDate", startDate );
            command.Parameters.AddWithValue("@dueDate", dueDate );
            command.Parameters.AddWithValue("@progress", progress );
            command.Parameters.AddWithValue("@status", status );
            command.Parameters.AddWithValue("@prID", prID );
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        } 
