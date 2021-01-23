     System.Data.SqlClient.SqlCommand c = new System.Data.SqlClient.SqlCommand();
     System.Data.DataTable T = new System.Data.DataTable();
     System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(c);
     c.commandtext = "select ..";
     DA.SelectCommand = c;
     c.Connection = new System.Data.SqlClient.SqlConnection(yourConnectionString);
     c.Connection.Open();
     DA.Fill(T);
            // close connection in finally block or use the using structure
