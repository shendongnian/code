    public static class Extensions
    {
        public static IEnumerable<Button> GetButtons(this Control control)
        {
            return control.Controls.OfType<Button>().OrderBy(b => b.Name);
        }
    }
