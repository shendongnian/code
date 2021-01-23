    public class NewLabel : Label
    {
        //...
        private int _borderWidth = 1;
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }
        private Color _borderColor = Color.Black;
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int xy = 0;
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            Pen pen = new Pen(_borderColor);
            for (int i = 0; i < _borderWidth; i++)
                e.Graphics.DrawRectangle(pen, xy + i, xy + i, width - (i << 1) - 1, height - (i << 1) - 1);
        }
    }
