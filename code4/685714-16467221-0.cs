        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            System.IntPtr ptrBorder = CreateRoundRectRgn(0, 0,
                this.ClientSize.Width, this.ClientSize.Height, 15, 15);
            SetWindowRgn(this.Handle, ptrBorder, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip,
                this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        }
