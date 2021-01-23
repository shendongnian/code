    public class AdvancedForm : Form
    {
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            foreach (Form f in this.OwnedForms)
            {
                f.Close();
            }
            base.OnFormClosing(e);
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            foreach (AdvancedForm f in this.OwnedForms)
            {
                switch (this.WindowState)
                {
                    case FormWindowState.Minimized:
                    case FormWindowState.Normal:
                        f.WindowState = this.WindowState;
                        break;
                    case FormWindowState.Maximized:
                        // just restore owned forms to their original sizes when parent form is maximized
                        f.WindowState = FormWindowState.Normal;
                        break;
                }
                // OnSizeChanged must be called, as changing WindowState property
                // does not raise SizeChanged event
                f.OnSizeChanged(EventArgs.Empty);
            }
        }
    }
