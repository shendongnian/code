    public class RoundControl : Control
    {
        private readonly GraphicsPath _path;
        private Pen _borderPen;
        public RoundControl()
        {
            _path = new GraphicsPath();
        }
        private Pen BorderPen
        {
            get
            {
                if (_borderPen == null)
                {
                    _borderPen = new Pen(ForeColor, Font.Size);
                }
                return _borderPen;
            }
        }
        private void ResetBorderPen()
        {
            if (_borderPen != null)
            {
                _borderPen.Dispose();
                _borderPen = null;
            }
        }
        protected override void OnFontChanged(EventArgs e)
        {
            ResetBorderPen();
            base.OnFontChanged(e);
        }
        protected override void OnResize(EventArgs e)
        {
            _path.Reset();
            _path.AddEllipse(ClientRectangle);
            Invalidate(Region);
            Region = new Region(_path);
            base.OnResize(e);
        }
        protected override void OnForeColorChanged(EventArgs e)
        {
            ResetBorderPen();
            base.OnForeColorChanged(e);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _path.Dispose();
                ResetBorderPen();
            }
            base.Dispose(disposing);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(BorderPen, ClientRectangle);
            base.OnPaint(e);
        }
    }
