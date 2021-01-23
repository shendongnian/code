    protected void SaveIntoDB_Click(object sender, EventArgs e)
        {
            string Str1 = (string)this.FindControl("Label1");
            SqlCommand sqlCmd = new SqlCommand("UPDATE table SET column1= @para1", sqlConn); 
            sqlCmd.Parameters.AddWithValue("@para1", Str1);
             try
               {
                 sqlConn.Open();
                 sqlCmd.ExecuteNonQuery();
                }
             finally
             {
                sqlConn.Close();
             }
        }
