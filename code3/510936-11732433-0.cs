        //Load customer ID to a combobox
        private void LoadCustomersId()
        {
            var connectionString = "connection string goes here";
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT Id FROM Customers";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            CustomerIdComboBox.Items.Add(reader.GetString("Id"));    
                        }
                    }    
                }
            }
        }
        //Load customer details using the ID
        private void LoadCustomerDetailsById(int id)
        {
            var connectionString = "connection string goes here";
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT Id, Firstname, Lastname FROM Customer WHERE Id = @customerId";
                using (var command = new MySqlCommand(query, connection))
                {
                    //Always use SQL parameters to avoid SQL injection and it automatically escapes characters
                    command.Parameters.AddWithValue("@customerId", id);
                    using (var reader = command.ExecuteReader())
                    {
                        //No customer found by supplied ID
                        if (!reader.HasRows)
                            return;
                        CustomerIdTextBox.Text = reader.GetInt32("Id").ToString();
                        FirstnameTextBox.Text = reader.GetString("Firstname");
                        LastnameTextBox.Text = reader.GetString("Lastname");
                    }
                }
            }
        }
        //Pass the selected ID in the combobox to the customer details loader method 
        private void CustomerIdComboBox_SelectedIndexChanged(object s, EventArgs e)
        {
            var customerId = Convert.ToInt32(CustomerIdComboBox.Text);
            LoadCustomerDetailsById(customerId);
        }
