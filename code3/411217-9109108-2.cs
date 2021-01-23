    public class myUserControls: UserControl
    {
        [Category("Category for UserControl")]
        public class ToolTipAdv : ToolTip
        {
            public ToolTipAdv (IContainer container) : base(container)
            {
                this.AutomaticDelay = 300;
                this.BackColor = System.Drawing.SystemColors.Highlight;
                this.ForeColor = System.Drawing.Color.White;
            }
            public void SetToolTip(Control ctrl, string caption)
            {
                ctrl.GotFocus += ShowToolTip;
                base.SetToolTip(ctrl, caption);
            }
            public void ShowToolTip(object sender, EventArgs e)
            {
                string message = base.GetToolTip((Control)sender);
                base.Show(message, (IWin32Window)sender, (sender as Control).Location);
            }
        }
    }
