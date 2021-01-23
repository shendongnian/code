    public static bool IsFromMasterPage(Control control)
    {
        if (control.Page.Master != null)
        {
            // Get all controls on the master page, excluding those from ContentPlaceHolders
            List<Control> masterPageControls = FindControlsExcludingPlaceHolderChildren(control.Page.Master);
            bool match = masterPageControls.Contains(control);
            return match;
        }
        return false;
    }    
    public static List<Control> FindControlsExcludingPlaceHolderChildren(Control parent)
    {
        List<Control> controls = new List<Control>();
        foreach (Control control in parent.Controls)
        {
            controls.Add(control);
            if (control.HasControls() && control.GetType() != typeof(ContentPlaceHolder))
            {
                controls.AddRange(FindControlsExcludingPlaceHolderChildren(control));
            }
        }
        return controls;
    }
