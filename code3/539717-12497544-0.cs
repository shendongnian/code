        private List<Point> _points = new List<Point>();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach(Point point in _points)
            {
                using (Pen Haitham = new Pen(Color.Silver, 2))
                {
                    e.Graphics.FillRectangle(Haitham.Brush, new Rectangle(point.X, point.Y, 50, 50));
                }
            }
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            _points.Add(new Point(e.X, e.Y));
            Invalidate(); // could be optimized to invalidate only the future rectangle draw
        }
