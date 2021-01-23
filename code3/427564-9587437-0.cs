      protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e) 
        {
 
            cn = new SqlConnection(conStr);
            cn.Open();
            delCmd = new SqlCommand("spDelEmployee",cn);
            delCmd.CommandType = CommandType.StoredProcedure;
            
            object id = GridView1.Rows[e.RowIndex].Cells[em.EmployeeID].Text.ToString();
            delCmd.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = Convert.ToInt32(id);
            
            delCmd.ExecuteNonQuery();
            
        }
