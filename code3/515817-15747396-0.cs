    cmd1.Connection = this.sqlConnection1;
    this.sqlConnection1.Open();
     foreach (GridViewRow row in your_grid.Rows)
            {
                Label id = (Label)row.FindControl("your_control"); //what ever control you are using
                SqlCommand cmd1 = new SqlCommand();
               
                cmd1.CommandText = "insert into your_table values (@p,@p1,@p2)";
                cmd1.Parameters.Add("@p", SqlDbType.VarChar).Value = your_control.Text;
                cmd1.Parameters.Add("@p1", SqlDbType.VarChar).Value = your_control.Text;
                cmd1.Parameters.Add("@p2", SqlDbType.VarChar).Value = your_control.Text;
                cmd1.CommandType = CommandType.Text;
                
                
                cmd1.ExecuteNonQuery();
                
            }
                this.sqlConnection1.Close();
