        void btnUserClick_Click(object sender, System.EventArgs e)
        {
            int userValue;
            if(int.TryParse(txtUserInput.Text, out userValue))
            {
                // We have the value successfully, do calculation
            }
            else
            {
                // We don't have the users value.
                MessageBox.Show("Please enter a valid integer into the text box.")
            }
        }
