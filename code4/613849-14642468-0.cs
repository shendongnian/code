    public static class Extensions
    {
        public static Control FindControlRecursively(this Control control, string id)
        {
            if (control.ID == id)
                return control;
            Control result = default(Control);
            foreach (Control child in control.Controls)
            {
                result = child.FindControlRecursively(id);
                if (result != default(Control)) break;
            }
            return result;
        }
    }
