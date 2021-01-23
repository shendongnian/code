    private void button_test_Click(object sender, EventArgs e)
    {
        try
        {
            string str = "data source=" + textBox_server.Text + "; initial catalog=" + textBox_db.Text
    + "; user id=" + textBox_user.Text + "; pwd=" + textBox_password.Text + ";";
            SqlConnection sqlcon = new SqlConnection(str);
            sqlcon.Open();
            sqlcon.Close();
            MessageBox.Show("Test Connection was successfull");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Test Connection failed. "+ ex.Message);
        }
    }
