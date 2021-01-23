    protected void saveBtn_Click(object sender, EventArgs e)
    {    
    // add variables
         string connectionInfo = (...)
         string commandText = (...)
        
        using (...){
            SqlCommand myCommand = (...)
            // add parameters
        
        try
        {
            connection.Open();
            myCommand.ExecuteNonQuery();
            connection.Close();
        }
        
        catch (Exception ex)
                {
                    (...)
                }
    }
