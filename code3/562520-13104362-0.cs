    if (actionButton.Text == "Update")
    {
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = "Data source=(local); Initial Catalog=INT422Assignment1; Integrated Security=SSPI;";
        cn.Open();
        MessageBox.Show(cn.ConnectionState.ToString());
    // If you are shown "Open" by above messagebox and you are using correct table and column names then you will get accurate results by following code
        SqlCommand cmd = cn.CreateCommand();
        cmd.CommandText = "SELECT firstName, lastName, phoneNumber, Comments FROM myTable WHERE firstName LIKE '" + firstNameTB.Text + "' AND lastName LIKE  '" + lastNameTB.Text + "' "; 
        SqlDataReader reader = cmd.ExecuteReader();
        string s = "";
        while (reader.Read())
        {
            s = reader["firstName"].ToString() + "-" + reader["lastName"].ToString() + reader["phoneNumber"].ToString() + reader["Comments"].ToString();
            MessageBox.Show(s);
        }    
        cn.Close();
    }
