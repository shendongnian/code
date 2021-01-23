    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e) {
        // Get the id
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
    
        // Create the delete query
        string sql = @"delete from GuestBook where id = @id";
    
        using (SqlConnection conn = dal.connectDatabase()) {
        
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@id"].Value = id;
        
            try {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    
        // Refresh the GridView1
        Bind_GridView1();
    }
