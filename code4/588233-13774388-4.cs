    private void saveAndExitBtn_Click(object sender, EventArgs e)
        {
            if (!isNumeric(custZipField.Text, System.Globalization.NumberStyles.Integer))
            {
                MessageBox.Show("Please enter a valid post code", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
    
            if (String.IsNullOrEmpty(custNameField.Text) || String.IsNullOrEmpty(custAddressField.Text) ||
                String.IsNullOrEmpty(custZipField.Text) || String.IsNullOrEmpty(custStateField.Text) ||
                String.IsNullOrEmpty(custAgeField.Text))
            {
                MessageBox.Show("Please complete the entire form", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    
            return;
            }
    
            //save the data
            saveNewCustomerInfo();
            //next, retrieve the hidden form's memory address
            Form myParentForm = CustomerAppStart.getParentForm();
            //now that we have the address use it to display the parentForm
            myParentForm.Show();
            //Finally close this form
            this.Close();
        }//end saveAndExitBtn_Click method
    
        public bool isNumeric(string val, System.Globalization.NumberStyles NumberStyle)
        {
            Double result;
            return Double.TryParse(val, NumberStyle,
                System.Globalization.CultureInfo.CurrentCulture, out result);
        }
