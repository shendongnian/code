        private void txtEmailID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidEmailAddress(txtEmailID.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtEmailID.Select(0, txtEmailID.Text.Length);
                // Set the ErrorProvider error with the text to display.  
                this.errorProvider1.SetError(txtEmailID, errorMsg);
            }
        }
        
        public bool ValidEmailAddress(string txtEmailID, out string errorMsg)
        {
            // Confirm that the e-mail address string is not empty. 
            if (txtEmailID.Length == 0)
            {
                errorMsg = "e-mail address is required.";
                return false;
            }
            // Confirm that there is an "@" and a "." in the e-mail address, and in the correct order.
            if (txtEmailID.IndexOf("@") > -1)
            {
                if (txtEmailID.IndexOf(".", txtEmailID.IndexOf("@")) > txtEmailID.IndexOf("@"))
                {
                    errorMsg = "";
                    return true;
                }
            }
            errorMsg = "e-mail address must be valid e-mail address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }
        private void txtEmailID_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(txtEmailID, "");
        }
     
