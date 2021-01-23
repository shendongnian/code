    public static class ControlExtensions
    {
        public static Control FindControlRecursive(this Control control, string id)
        {
            if (control == null) return null;
            //try to find the control at the current level
            Control ctrl = control.FindControl(id);
            if (ctrl == null)
            {
                //search the children
                foreach (Control child in control.Controls)
                {
                    ctrl = FindControlRecursive(child, id);
                    if (ctrl != null) break;
                }
            }
            return ctrl;
        }
    }
