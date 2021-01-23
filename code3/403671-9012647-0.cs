        public class FlyoutImageButton : Button
        {
            bool _isHovering = false;
            public FlyoutImageButton() : base()
            {
                MouseEnter += (sender, e) => _isHovering = true;
                MouseLeave += (sender, e) => _isHovering = false;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                if (_isHovering)
                    base.OnPaint(e);
                else
                {
                    if (this.Image != null)
                    {
                        e.Graphics.Clear(BackColor);
                        if (this.Enabled)
                            e.Graphics.DrawImageUnscaled(
                                this.Image,
                                (this.Width - this.Image.Width) / 2,
                                (this.Height - this.Image.Height) / 2);
                        else
                            ControlPaint.DrawImageDisabled(
                                e.Graphics,
                                this.Image,
                                (this.Width - this.Image.Width) / 2,
                                (this.Height - this.Image.Height) / 2,
                                BackColor);
                    }
                    if (this.DesignMode)
                        ControlPaint.DrawBorder(
                            e.Graphics, ClientRectangle, SystemColors.ControlDarkDark, ButtonBorderStyle.Dashed);
                }
            }
        }
