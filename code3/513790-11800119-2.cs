    private Control FindControlRecursive(Control rootControl, string controlId)
    {
        if (rootControl.ID == controlId)
        {
            return rootControl;
        }
    
        foreach (Control controlToSearch in rootControl.Controls)
        {
            Control controlToReturn = FindControlRecursive(controlToSearch, controlId);
            if (controlToReturn != null)
            {
                return controlToReturn;
            }
        }
    
        return null;
    }
