    public static class ControlExtensions
    {
        public static Control FindControlRecursively(this Control control, string targetControlID)
        {
            if (control == null)
            {
                return null;
            }
            var ctrl = control.FindControl(targetControlID);
            if (ctrl == null)
            {
                foreach (Control child in control.Controls)
                {
                    ctrl = FindControlRecursively(child, targetControlID);
                    if (ctrl != null)
                    {
                        break;
                    }
                }
            }
            return ctrl;
        }
    }
