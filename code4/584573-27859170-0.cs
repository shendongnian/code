    namespace System.Windows.Forms
    {
        public static class ToolTipEx
        {
            private static void SetTipRecurse(ToolTip toolTip, Control control, string tip)
            {
                toolTip.SetToolTip(control, tip);
    
                foreach (Control child in control.Controls)
                    SetTipRecurse(toolTip, child, tip);
            }
    
            public static void SetTooltip(this ToolTip toolTip, UserControl control, string tip)
            {
                SetTipRecurse(toolTip, control, tip);
            }
        }
    }
