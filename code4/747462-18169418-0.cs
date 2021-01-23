    public static class ControlExtensions
    {
        public static List<Control> GetChildrenRecursive(this Control control)
        {
            var result = new List<Control>();
            foreach (Control childControl in control.Controls)
            {
                result.Add(childControl);
                if (childControl.Controls.Count > 0)
                {
                    result.AddRange(GetChildrenRecursive(childControl));
                }
            }
            return result;
        }
    }   
