    class ImageLabel : Label
    {
        public ImageLabel()
        {
            ImageAlign = ContentAlignment.MiddleLeft;
        }
        private Image _image;
        public new Image Image
        {
            get { return _image; }
            set
            {
                const int spacing = 4;
                if (_image != null)
                    Padding = new Padding(Padding.Left - spacing - _image.Width, Padding.Top, Padding.Right, Padding.Bottom);
                if (value != null)
                    Padding = new Padding(Padding.Left + spacing + value.Width, Padding.Top, Padding.Right, Padding.Bottom);
                _image = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                Rectangle r = CalcImageRenderBounds(Image, ClientRectangle, ImageAlign);
                e.Graphics.DrawImage(Image, r);
            }
            base.OnPaint(e); // Paint text
        }
    }
