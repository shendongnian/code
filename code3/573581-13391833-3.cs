    private void ValidateText(object sender, EventArgs e)
    {
        TextBox txtBox = sender as TextBox;
        String strpattern = @"^[a-zA-Z][a-zA-Z0-9\'\' ']{1,20}$"; //Pattern is Ok
        Regex regex = new Regex(strpattern);
        if (!regex.Match(txtBox.Text).Success)
        {
            // passed
        }
    }
