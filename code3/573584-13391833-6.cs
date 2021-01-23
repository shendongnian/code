    private void SetProperty(Control ctr)
    {
        foreach (Control control in ctr.Controls)
        {
            if (control is TextBox)
            {
                control.Validating += ValidateText;
            }
            else
            {
                if (control.HasChildren)
                {
                    SetProperty(control);  //Recursive function if the control is nested
                }
            }
        }
    }
    private void ValidateText(object sender, CancelEventArgs e)
    {
        TextBox txtBox = sender as TextBox;
        String strpattern = @"^[a-zA-Z][a-zA-Z0-9\'\' ']{1,20}$"; //Pattern is Ok
        Regex regex = new Regex(strpattern);
        //What should I write here?
        if (!regex.Match(txtBox.Text).Success)
        {
            e.Cancel = true;
        }
        e.Cancel = false;
    }
