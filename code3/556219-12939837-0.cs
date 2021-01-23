    string strcon = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\VC_temps.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"; 
    // Use "using" statement to guarantee connection is closed even if exception occurs
    using (SqlConnection con = new SqlConnection(strcon))
    {
        con.Open(); 
        using (SqlCommand com = con.CreateCommand("Store-Jobs"))
        {
            com.CommandType = CommandType.StoredProcedure; 
            com.Parameters.AddWithValue("Job", TextBox1.Text); 
            com.Parameters.AddWithValue("JobType", DropDownList1.Text); 
            com.Parameters.AddWithValue("StartDate", TextBox3.Text); 
            com.Parameters.AddWithValue("Time", TextBox2.Text); 
            com.Parameters.AddWithValue("JobID", TextBox1.Text.Substring(3).ToUpper()); 
            com.Parameters.AddWithValue("CompanyID", ); 
            com.Parameters.AddWithValue("PositionFilled", "NO"); 
            com.Parameters.AddWithValue("Description", TextBox4.Text); 
            com.ExecuteNonQuery(); 
        }
    }
    Labelinfo.Text = "Post successful."; 
