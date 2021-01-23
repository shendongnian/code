     public Control FindControlRecursive(string id, ControlCollection ctrls)
        {
            foreach (Control c in ctrls)
            {
                Control child = FindControlRecursive(id, ctrls.Controls);
                if (child != null)
                {
                    return child;
                }
            }
            return null;
        }
