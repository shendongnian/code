    int count = cmd2.ExecuteNonQuery();    
    if (count > 0)
    {
        MessageBox.Show(" details Entered Successfully");
        clear();
    }
    else
        MessageBox.Show("Details Not Entered");
       
    con.Close();
