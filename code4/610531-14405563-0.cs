            private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                //has no value
            }
            else
            {
                FirstName = txtName.Text;
            }
        }
        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                //has no value
            }
            else
            {
                Address = txtAddress.Text;
            }
        }
