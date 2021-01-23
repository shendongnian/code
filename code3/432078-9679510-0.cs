        using (SqlConnection conn = new SqlConnection(connString))
        {
              using (SqlCommand cmd = new SqlCommand(updateCommand, conn))
              {
                  cmd.Parameters.Clear();
                  cmd.Parameters.AddWithValue("@StatusID", suggestionStatus);
                  cmd.Parameters.AddWithValue("@ID", ID);
                  conn.Open(); 
                  cmd.ExecuteNonQuery();
              }
             conn.Close();
        }
           GridView2.DataBind();
           UpdatePanel1.Update();
