    protected void blabla(object sender, ServerValidateEventArgs e)
    {
        if (string.IsNullOrEmpty(TB1.Text) && string.IsNullOrEmpty(TB2.Text))
            e.IsValid = false;
        else
            e.IsValid = true;
    }
