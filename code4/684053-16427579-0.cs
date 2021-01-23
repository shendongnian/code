    public partial class SomeUserControl : UserControl
    {
        private TrapMouseDownOnScrollArea trapScroll = null;
        public SomeUserControl()
        {
            InitializeComponent();
            this.VisibleChanged += new EventHandler(SomeUserControl_VisibleChanged);
        }
        void SomeUserControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && trapScroll == null)
            {
                trapScroll = new TrapMouseDownOnScrollArea(this.panel1);
            }
        }
        private class TrapMouseDownOnScrollArea : NativeWindow
        {
            private Control control = null;
            private const int WM_NCLBUTTONDOWN = 0xA1;
            public TrapMouseDownOnScrollArea(Control ctl)
            {
                if (ctl != null && ctl.IsHandleCreated)
                {
                    this.control = ctl;
                    this.AssignHandle(ctl.Handle);
                }
            }
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_NCLBUTTONDOWN:
                        if (this.control != null)
                        {
                            Rectangle screenBounds = control.RectangleToScreen(new Rectangle(0, 0, control.Width, control.Height));
                            if (screenBounds.Contains(Cursor.Position))
                            {
                                control.Focus();
                            }
                        }
                        break;
                }
                base.WndProc(ref m);
            }
        }
    }
