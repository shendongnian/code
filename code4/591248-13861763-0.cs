    public static class ControlExtensions
    {
        public static Control FindControlRecursive(this Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }
    
            foreach (Control c in root.Controls)
            {
                Control t = c.FindControlRecursive(id);
                if (t != null)
                {
                    return t;
                }
            }
    
            return null;
        }
    }
