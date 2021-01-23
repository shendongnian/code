    private void WRTODB_Click(object sender, EventArgs e)        
    {
        try
        {
            using (SqlConnection dbConnection = new SqlConnection()) 
            {
                dbConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+@"C:\Users\sgarner\Google Drive\Visual Studio 2012\Timer test\WRITE TO DB\WRITE TO DB\Machine_Stop.accdb";
                dbConnection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO DV1(TIME,CODE,REASON) VALUES ([pTime],[pCode],[pReason])", dbConnection))
                {
                    command.Parameters.AddWithValue("pTime", DateTime.Now);
                    command.Parameters.AddWithValue("pCode", textBox1.Text);
                    command.Parameters.AddWithValue("pReason", textBox2.Text);
                    command.ExecuteNonQuery();
                }
                dbConnection.Close();
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
 
