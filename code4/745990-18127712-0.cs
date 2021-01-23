        Bitmap _bitmap = new Bitmap(PictureBox1.Width, PictureBox1.Height);
        Dictionary<int, Image> _images = new Dictionary<int, Image>();
        System.Drawing.Pen _redPen = new System.Drawing.Pen(Color.Red, 15);
        bool _linePresent = false;
        int[] _imageIndex = { 1, 2, 1 };
        public void Init()
        {
            _images.Add(1, Image.FromFile("Melon.png"));
            _images.Add(2, Image.FromFile("Pineapple.png"));
            PictureBox1.Image = _bitmap;
        }
        public void Update()
        {
            Graphics graphics = Graphics.FromImage(_bitmap);
            graphics.Clear(Color.White);
            graphics.DrawImage(_images[_imageIndex[0]], 50, 100);
            graphics.DrawImage(_images[_imageIndex[1]], 350, 100);
            graphics.DrawImage(_images[_imageIndex[2]], 650, 100);
            if (_linePresent)
                graphics.DrawLine(_redPen, new Point(10, 150), new Point(900, 150));
        }
