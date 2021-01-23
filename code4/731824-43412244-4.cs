        const uint WM_NCHITTEST = 0x0084, WM_MOUSEMOVE = 0x0200,
                     HTLEFT = 10, HTRIGHT = 11, HTBOTTOMRIGHT = 17,
                     HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTTOP = 12,
                     HTTOPLEFT = 13, HTTOPRIGHT = 14;
        Size formSize;
        Point screenPoint;
        Point clientPoint;
        Dictionary<uint, Rectangle> boxes;
        const int RHS = 10; // RESIZE_HANDLE_SIZE
        bool handled;
        protected override void WndProc(ref Message m)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                base.WndProc(ref m);
                return;
            }
            handled  = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                formSize    = this.Size;
                screenPoint = new Point(m.LParam.ToInt32());
                clientPoint = this.PointToClient(screenPoint);
                boxes = new Dictionary<uint, Rectangle>() {
                    {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RHS, RHS, RHS)},
                    {HTBOTTOM, new Rectangle(RHS, formSize.Height - RHS, formSize.Width - 2*RHS, RHS)},
                    {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RHS, formSize.Height - RHS, RHS, RHS)},
                    {HTRIGHT, new Rectangle(formSize.Width - RHS, RHS, RHS, formSize.Height - 2*RHS)},
                    {HTTOPRIGHT, new Rectangle(formSize.Width - RHS, 0, RHS, RHS) },
                    {HTTOP, new Rectangle(RHS, 0, formSize.Width - 2*RHS, RHS) },
                    {HTTOPLEFT, new Rectangle(0, 0, RHS, RHS) },
                    {HTLEFT, new Rectangle(0, RHS, RHS, formSize.Height - 2*RHS) }
                };
                foreach (var hitBox in boxes)
                {
                    if (hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled  = true;
                        break;
                    }
                }
            }
            if (!handled)
                base.WndProc(ref m);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor,
                    this.ClientSize.Width - 16, this.ClientSize.Height - 16, 16, 16);
            }
            base.OnPaint(e);
        }
