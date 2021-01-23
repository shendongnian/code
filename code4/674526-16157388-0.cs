    private void btnsave_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(txtfname.Text) ||
            txtfname.Text.Any(c => Char.IsNumber(c)) ) {
            MessageBox.Show("Please enter your First Name");
            txtfname.Focus();
        }
    }
