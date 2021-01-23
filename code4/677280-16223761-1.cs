    bool success = false;
    string error = null;
    using (OleDbDataReader dbReader = cmd.ExecuteReader())
    {
        try
        {
            while (dbReader.Read())
            {
                if (dbReader.HasRows)
                {
                    selectedUser.custID = (int)dbReader[0];
                    selectedUser.firstName = (string)dbReader[1];
                    selectedUser.lastName = (string)dbReader[2];
                    selectedUser.phoneNum = (string)dbReader[3];
                    selectedUser.custEmail = (string)dbReader[4];
                    selectedUser.userName = (string)dbReader[5];
                    selectedUser.password = (string)dbReader[6];
                    success = true;
                }
            }
        }
        catch (Exception e)
        {
            error = e.ToString();
        }
    }
    if (success)
    {
        MessageBox.Show("Login successful!");
        HotelSearchForm hotelsearchForm = new HotelSearchForm();
        hotelsearchForm.ShowDialog();
        return selectedUser;
    }
    MessageBox.Show(error);
    return null;
