    HidePanels(this.Controls);
    
    ...
    
    private void HidePanels(ControlCollection controls)
    {
        foreach (Control c in controls)
        {
            if (c is Panel)
            {
                c.Visible = false;
            }
            
            // hide any panels this control may have
            HidePanels(c.Controls);
        }
    }
