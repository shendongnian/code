    private void txtAlphaOnly_TextChanged(object sender, EventArgs e)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", txtAlphaOnly.Text))
        {
            MessageBox.Show("Alphabets Only Allowed");            
        }
    }
