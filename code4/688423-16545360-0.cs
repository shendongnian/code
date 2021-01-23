    private void ToggleAllTextBoxControls()
    {
        foreach (Control c in this.Controls)
            if (c Is TextBox)
                 c.Enabled = chkEnable.Checked;
    }  
