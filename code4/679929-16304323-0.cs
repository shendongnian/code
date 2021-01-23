    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["userID"].ToString());
            string deleteStatement = "Delete from Table1 where userID=@userID";
            string deleteStatement2 = "Delete from Table2 where userID=@userID";
            using (SqlConnection connection = new SqlConnection(CS()))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = deleteStatement;
                cmd.Parameters.Add(new SqlParameter("@userID", userID));
                cmd.ExecuteNonQuery();
                cmd.CommandText = deleteStatement2;
                int result = cmd.ExecuteNonQuery();
                if (result == 1) BindData();
            }
        }
