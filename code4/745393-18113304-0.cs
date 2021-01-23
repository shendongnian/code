        private void Form()
        {
            txtFirstName.TextChanged += TextBoxChanged;
            txtLastName.TextChanged += TextBoxChanged;
        }
        private void TextBoxChanged(object sender, EventArgs e)
        {
            txtFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
        }
