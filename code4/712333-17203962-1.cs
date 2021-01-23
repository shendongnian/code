    string commandText = "SELECT * FROM table WHERE firstname = @firstname and lastname = @lastname";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        if (listbox1.SelectedItem == null)
        {
             // exit since nothing was selected in the listbox to query by
        }
        var names = listbox1.SelectedItem.ToString().Split(' ');
        if (names.Length != 2)
        {
             // exit since this is not what we want and will yield unexpected results
        }
        string firstName = names[0];
        string lastName = names[1];
        command.Parameters.AddWithValue("@firstname", firstname);
        command.Parameters.AddWithValue("@lastname", lastname);
        
        // Read information from database...
    
    }
