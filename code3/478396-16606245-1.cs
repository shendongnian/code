      var connection = (System.Data.SqlClient.SqlConnection) _db.Database.Connection;
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var dt = new DataTable();
            using (var com = new System.Data.SqlClient.SqlDataAdapter("Select * from Table", connection))
            {
                com.Fill(dt);
            }
