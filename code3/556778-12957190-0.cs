    private void FirstnameText_Validating (object sender, CancelEventArgs e)
    {
        string error = null;
        
        if (FirstnameText.Text.Length == 0)
        {
            error = "You must enter a First Name";
            e.Cancel = true; // This is important to keep focus in the box until the error is resolved.
        }
        ErrorProvider.SetError((Control)sender, error); // FirstnameText instead of sender to avoid unboxing the object if you care that much
    }
