    string strSQL = @"UPDATE info 
                      SET DAYS = @DAYS,
                          PENALTY1 = @PENALTY1,
                          PENALTY2 = @PENALTY2,
                          CORRECTION = @CORRECTION,
                          DATE = @DATE
                    WHERE ID = @ID";
    string connStr = WebConfigurationManager.ConnectionStrings["asgdb01ConnectionString"].ConnectionString;
    using (SqlConnection conn = new SqlConnection(connStr))
    {
    	using (SqlCommand comm = new SqlCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = strSQL;
    		comm.CommandType = CommandType.Text;
            comm.Parameters.Add(new SqlParameter("@ID", Int32.Parse(DropDownList1.SelectedItem.Value)));
            comm.Parameters.Add(new SqlParameter("@DATE", CalendarExtender1.SelectedDate));
            comm.Parameters.Add(new SqlParameter("@DAYS", Int32.Parse(TextBox3.Text)));
            comm.Parameters.Add(new SqlParameter("@PENALTY1", Int32.Parse(TextBox4.Text)));
            comm.Parameters.Add(new SqlParameter("@PENALTY2", Int32.Parse(TextBox5.Text)));
            comm.Parameters.Add(new SqlParameter("@CORRECTION", Int32.Parse(TextBox6.Text)));
    		try
    		{
    			conn.Open();
    			int i = comm.ExecuteNonQuery();
    			if (i > 0)
    			{
    				Response.Write("Success ! ");
    			}
    			else
    			{
    				Response.Write("No record was updated ");
    			}
    		}
    		catch(SqlException ex)
    		{
    			Response.Write(ex.ToString());
    		}
    	}
    }
