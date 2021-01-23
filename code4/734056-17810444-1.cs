    public static class CustomizedUIHelper
    {
        public static void AddCustomizedUI(Control control, PaintEventArgs e)
        {
            // gain access to new properties
            ICustomizedUI customizedUI = control as ICustomizedUI;
            if (customizedUI != null)
            {
                // perform the checks necessary and add the new UI changes
            }
        }
    }
