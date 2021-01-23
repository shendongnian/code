    class MyLabel: Label
    {
        private bool _autoSize = true;
        /// <summary>
        /// Get or set auto size
        /// </summary>
        public new bool AutoSize
        {
            get { return _autoSize; }
            set
            {
                _autoSize = value;
                Invalidate();
            }
        }
        public MyLabel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            base.AutoSize = false;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // auto size
            if (_autoSize)
            {
                SizeF size = e.Graphics.MeasureString(Text, Font);
                if (ClientSize.Width < (int)size.Width + 1 || ClientSize.Width > (int)size.Width + 1 ||
                ClientSize.Height < (int)size.Height + 1 || ClientSize.Height > (int)size.Height + 1)
                {
                    // need resizing
                    ClientSize = new Size((int)size.Width + 1, (int)size.Height + 1);
                    return;
                }
            }
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.Black, Color.LightGray, LinearGradientMode.ForwardDiagonal))
            e.Graphics.DrawString(Text, Font, brush, ClientRectangle);
        }
    }
