    // define your INSERT statement with PARAMETERS
    string insertStmt = "INSERT INTO dbo.Table1(title, datee, post, cat, imageurl) " +
                        "VALUES(@title, @datee, @post, @cat, @imageurl)";
    // define connection and command
    using(SqlConnection conn = new SqlConnection(yourConnectionStringHere))
    using (SqlCommand cmd = new SqlCommand(insertStmt, conn))
    {
         // define parameters and set their values
         cmd.Parameters.Add("@title", SqlDbType.NVarChar, 100).Value = TextBox1.Text.Trim();
         cmd.Parameters.Add("@datee", SqlDbType.DateTime).Value = DateTime.Now;
         cmd.Parameters.Add("@post", SqlDbType.NVarChar, 100).Value = TextBox2.Text.Trim();
         cmd.Parameters.Add("@cat", SqlDbType.NVarChar, 100).Value = DropDownList1.SelectedItem.Text.Trim();
         cmd.Parameters.Add("@imageurl", SqlDbType.NVarChar, 250).Value = path;
         // open connection, execute query, close connection
         conn.Open();
         int rowsInserted = cmd.ExecuteNonQuery();
         conn.Close();
    }
