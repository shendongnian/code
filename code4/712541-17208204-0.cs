    // in Form1.cs
    private void btn_Click(object sender, System.EventArgs e) {
       OpenDatabaseConnection();
       string customerName=SearchCustomerByCode(someTextBox.Text); 
       someOtherTextBox.Text=customerName;
       CloseDatabaseConnection();
    }
