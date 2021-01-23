    public static class ControlExtensions
    {
        public static void SetContextMenuOnChildTextBoxes(this Control control)
        {
            if (control is TextBox)
            {
                control.ContextMenu = new ContextMenu();
            }
            if (control.Controls != null)
            {
                foreach (Control controlChild in control.Controls)
                {
                    controlChild.SetContextMenuOnChildTextBoxes();
                }
            }
        }
    }
