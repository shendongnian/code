    public void ProcessControl(Control control, string ctrlName)
    {
        foreach (Label c in control.Controls.OfType<Label>())
       {
           // It's a label for an input
           if (c.ID.Substring(0, 8) == ctrlName)
           {
                // Do some stuff with the control here
           }
        }
    
        foreach (Control ctrl in control.Controls)
        {
            ProcessControl(ctrl, ctrlName);        
        }    
    }
