     protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
      {
        int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["userID"].ToString());
        string deleteStatement = "Delete from Table1 where userID=@userID";
        string deleteStatement2 = "Delete from Table2 where userID=@userID";
        using (SqlConnection connection = new SqlConnection(CS()))
        {
        connection.Open();
            
        using (SqlCommand cmd = new SqlCommand(deleteStatement, connection))
        {
            cmd.Parameters.Add(new SqlParameter("@userID", userID));
            cmd.ExecuteNonQuery();
        }
          using (SqlCommand cmd2 = new SqlCommand(deleteStatement2, connection))
            {
                cmd2.Parameters.Add(new SqlParameter("@userID", userID));
                int result2 = cmd2.ExecuteNonQuery();
                if (result2 == 1)
                {
                    BindData();
                }
            }
         }
    }
