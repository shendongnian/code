        private SizeF _autoScaleFactor;
        private Size _originalClientSize;
        protected override void SetClientSizeCore(int x, int y)
        {
            base.SetClientSizeCore(x, y);
            _autoScaleFactor = AutoScaleFactor;
            _originalClientSize = new Size(x, y);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            AutoScaleClientSize();
            base.OnHandleCreated(e);
        }
        private void AutoScaleClientSize()
        {
            var dx = _autoScaleFactor.Width;
            if (!dx.Equals(1.0F))
            {
                _originalClientSize.Width = (int)Math.Round(_originalClientSize.Width * dx);
            }
            var dy = _autoScaleFactor.Height;
            if (!dy.Equals(1.0F))
            {
                _originalClientSize.Height = (int)Math.Round(_originalClientSize.Height * dy);
            }
            ClientSize = _originalClientSize;
        }
