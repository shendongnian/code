    SqlConnection xconn=new SqlConnection(Write your connection string);
    SqlCommand xcommand=new SqlCommand("Test",xconn);
    xcommand.CommandType=CommandType.StoredProcedure;
    xcommand.Parameters.AddWithValue("@SearchItem",DbType.String,txtBox1.Text);
    xconn.Open();
    xCommand.ExecuteNonQuery();
    xconn.Close();
