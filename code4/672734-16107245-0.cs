	SqlConnection connection = new SqlConnection(@"Data Source=C:\\temp\\Project\\WindowsFormsApplication2\\Database.sdf");
    connection.Open();
    SqlCommand command = new SqlCommand("SELECT * FROM Technician WHERE Name = '" + txt_username.Text + "' AND Password = '" + txt_password.Text + "' ");
    int row=command.ExecuteNonQuery();
    if (row>0)
    {
        MessageBox.Show("Login Successful");
        System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(MainMenuForm));
        t.Start();
        this.Close();
    }
    else
    {
        MessageBox.Show("Login Unsuccessful");
        return;
    }
    connection.Close();
}
