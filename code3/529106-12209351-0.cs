    public class Controls
    {
        private Control contentPanel = null;
        private ThemedForm themedform = null;
        public Controls(ThemedForm form, Control panel)
        {
            contentPanel = panel;
            themedform = form;
        }
        public void Add(Control control)
        {
            if (control != contentPanel)
            {
                contentPanel.Controls.Add(control);
            }
            else
            {
                themedform.Controls_Add(control);
            }
        }
        public void Remove(Control control)
        {
            if (control != contentPanel)
            {
                contentPanel.Controls.Remove(control);
            }
            else
            {
                themedform.Controls_Remove(control);
            }
        }
    }
