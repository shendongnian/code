    protected void submitButton_Click(object sender, EventArgs e)
        {
            string constr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=U:\App_Data\Registrationinfo.mbd";
            string cmdstr = "insert into UserInfo(FName, LName) values(@First, @Last)";
    
            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand com = new OleDbCommand(cmdstr, con);
            con.Open();
            com.Parameters.AddWithValue("@First", labelFirstName.Text);
            com.Parameters.AddWithValue("@Last", labelLastName.Text);
            com.ExecuteNonQuery();
            con.Close();
        }
