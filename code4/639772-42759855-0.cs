    public static void ApplyToAll<T>(this Control.ControlCollection controlCollection, string tagFilter, Action action)
    {
        foreach (Control control in controlCollection)
        {
            if (!string.IsNullOrEmpty(tagFilter))
            {
                if (control.Tag == null)
                {
                    control.Tag = "";
                }
 
                if (!string.IsNullOrEmpty(tagFilter) && control.Tag.ToString() == tagFilter && control is T)
                {
                    action(control);
                }
            }
            else
            {
                if (control is T)
                {
                    action(control);
                }
            }
 
            if (control.Controls != null && control.Controls.Count > 0)
            {
                ApplyToAll(control.Controls, tagFilter, action);
            }
        }
    }
