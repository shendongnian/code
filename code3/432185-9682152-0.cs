    private void BindGrid ()
    { 
    
            var dt = new DataTable();
            var connection = new SqlConnection(YOUR CONNECTION); 
    
            try
            {
              connection.Open();
              var query = "YOUR SEARCH QUERY";
              var sqlCmd = new SqlCommand(query, connection);
              var sqlDa = new SqlDataAdapter(sqlCmd);
              sqlDa.Fill(dt);
    
                  if (dt.Rows.Count > 0)
                  {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                  }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                    //
            }
            finally
            {
                connection.Close();
            }
    }
