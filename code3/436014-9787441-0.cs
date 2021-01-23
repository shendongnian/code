    public static class ControlExtensions
    {
        public static void SetControlChildText(this Control rootControl, String text, bool recursive)
        {
            var allChildTextControls = rootControl.Controls.OfType<ITextControl>();
            foreach (ITextControl txt in allChildTextControls)
                txt.Text = text;
    
            if (recursive) {
                foreach (Control child in rootControl.Controls)
                    child.SetControlChildText(text, true);
            }
        }
    }
