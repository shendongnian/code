    string connetionString = "Data Source=UMAIR;Initial Catalog=Air; Trusted_Connection=True;" ;
    // [ ] required as your fields contain spaces!!
    string insStmt = "insert into Main ([First Name], [Last Name]) values (@firstName,@lastName)";
    using (SqlConnection cnn = new SqlConnection(connetionString))
    {
        cnn.Open();
        SqlCommand insCmd = new SqlCommand(insStmt, cnn);
        // use sqlParameters to prevent sql injection!
        insCmd.Parameters.AddWithValue("@firstName", textbox2.Text);
        insCmd.Parameters.AddWithValue("@lastName", textbox3.Text);
        int affectedRows = insCmd.ExecuteNonQuery();
        MessageBox.Show (affectedRows + " rows inserted!");
    }
    
