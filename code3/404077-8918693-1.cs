    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) 
    { 
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            SqlConnection con = new SqlConnection(strConnString);  
            con.Open(); 
    
            string Users = e.Row.Cells[0].Text; // current row being bound
     
            string strQuery = "insert into Table1 (FileName, DateTimeUploaded, Type, Username)" + 
            " values(@FileName, @DateTimeUploaded, @Type, @Username)"; 
            SqlCommand cmd = new SqlCommand(strQuery); 
     
            cmd.Parameters.AddWithValue("@FileName", datalink); 
            cmd.Parameters.AddWithValue("@Type", ext); 
            cmd.Parameters.AddWithValue("@DateTimeUploaded", DateTime.Now); 
            cmd.Parameters.AddWithValue("@Username", Users); 
     
            cmd.CommandType = CommandType.Text; 
            cmd.Connection = con; 
            cmd.ExecuteNonQuery(); 
    
            con.Close(); 
            con.Dispose(); 
         }
     } 
