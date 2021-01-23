    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        TextBox tb = sender as TextBox;
        if (tb != null)
        {
            DateTime res;
            e.Cancel = !DateTime.TryParse(tb.Text, out res);
            if (e.Cancel)
            {
               // if you have an errorProvider...
               this.errorProvider1.SetError(
                     tb, 
                     String.Format("'{0}' is not a valid date", tb.Text));
            }
        }
    }
    
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        // add extra checks to determine if
        // this char is allowed, set Handled to 
        // false. If you want to surpress the key
        // set it to true
        // get the current separator or have your own, then simply say @"/"
        var dateSep = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
        e.Handled = !(Char.IsDigit(e.KeyChar) ||
                    (dateSep.IndexOf(e.KeyChar)>-1) ||
                    Char.IsControl(e.KeyChar));    
    }
