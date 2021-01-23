    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        TextBox tb = sender as TextBox;
        if (tb != null)
        {
            DateTime res;
            e.Cancel = !DateTime.TryParse(tb.Text, out res);
        }
    }
    
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        // add extra checks to determine if
        // this char is allowed, set Handled to 
        // false. If you want to surpress the key
        // set it to true
        e.Handled = !(Char.IsDigit(e.KeyChar) ||
                        (e.KeyChar == '\\') ||
                        Char.IsControl(e.KeyChar));
    }
