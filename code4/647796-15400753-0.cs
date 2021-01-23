    private void saveButton_Click(object sender, EventArgs e)
    {
    	// check if the Id is a integer
    	int convertedId;
    	if (!int.TryParse(customerIDTextBox.Text, out convertedId))
    	{
    		MessageBox.Show("The ID is not a integer value");
    		return;
    	}
    	
    	myCustomer.Id = convertedId;
    	myCustomer.Name = fullNameTextBox.Text;
    	myCustomer.Address = addressTextBox.Text;
    	myCustomer.Email = emailTextBox.Text;
    	myCustomer.Phone = phoneNumberTextBox.Text;
    	
    	// check if the DateTime is a valid dateTeime
    	DateTime convertedDate;
    	if (!DateTime.TryParseExact(addressTextBox.Text,"MM/dd/yyyy", null, System.Globalization.DateTimeStyles.AssumeLocal, out convertedDate))
    	{
    		MessageBox.Show("The filed is not a valid date");
    		return;
    	}
    	
    	myCustomer.AddDate = convertedDate;
    	
    	
    	myCustomer.TotalTransactions = Convert.ToInt32(totalTransactionsTextBox.Text);
    }
