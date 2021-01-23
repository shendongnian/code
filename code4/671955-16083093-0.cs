    private void button_retrieve_Click(object sender, EventArgs e)
    {
    var selectSQL = "select Firstname, Lastname, Email, Address Inimesed where email = @email";
    string connectionString = @"Data Source=myDatabase;Password=xxxxxx;";
    using (var cn = new SqlCeConnection(connectionString))
    using (var cmd = new SqlCeCommand(selectSQL, cn))
    {
         cn.Open();
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
        cmd.Parameters["Email"].Value = "emailaddresstofind";
        var rdr = cmd.ExecuteReader();
        try
        {
            if (rdr.Read())
            {
                textBox1_Firstname.Text = rdr.GetString(0);
                textBox2_Lastname.Text = rdr.GetString(1);
                textBox3_Email.Text = rdr.GetString(2);
                textBox4_Address.Text = rdr.GetString(3);
            }
            else
            {
                MessageBox.Show("Could not find record");
            }
        }    
        finally
        {
            rdr.Close();
            cn.Close();
        }
    }
}
