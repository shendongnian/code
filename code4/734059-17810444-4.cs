    public static class CtrlHelper
    {
        public static void HandleUI(Control control, PaintEventArgs e)
        {
            // gain access to new properties
            ICtrl ctrl = control as ICtrl;
            if (ctrl != null)
            {
                // perform the checks necessary and add the new UI changes
            }
        }
    }
