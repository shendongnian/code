    public static class UIHelper
    {
        public static void RegesterButtonClicks(Form form, EventHandler method)
        {
            foreach (Control control in form.Controls)
            {
                if (control is Button)
                {
                    control.Click += method;
                }
            }
        }
    }
