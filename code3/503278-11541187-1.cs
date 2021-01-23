    public static class Extensions
    {
        public static Control FindControl(this Page page, string id, bool recursive)
        {
            return ((Control)page).FindControl(id, recursive);
        }
        public static Control FindControl(this Control control, string id, bool recursive)
        {
            if (recursive)
            {
                if (control.ID == id)
                    return control;
                foreach (Control ctl in control.Controls)
                {
                    Control found = ctl.FindControl(id, recursive);
                    if (found != null)
                        return found;
                }
                return null;
            }
            else
            {
                return control.FindControl(id);
            }
        }
        public static Control FindAncestor(this Control control, Func<Control, bool> predicate)
        {
            if (predicate(control))
                return control;
            if (control.Parent != null)
                return control.Parent.FindAncestor(predicate);
            
            return null;
        }
    }
