    public void ProcessControl(Control control, string ctrlName)
    {
        if (control is Label && control.ID.Substring(0, 8) == ctrlName)
        {
            // Do some stuff with the control here
        }
    
        foreach (Control ctrl in control.Controls)
        {
            ProcessControl(ctrl, ctrlName);        
        }    
    }
