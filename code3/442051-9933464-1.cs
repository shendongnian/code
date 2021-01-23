    public static class ControlExtension
    {
        public static IEnumerable<Control> GetAllControls(this Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                yield return control;
                foreach (Control child in control.GetAllControls())
                {
                    yield return child;
                }
            }
        }
    }
