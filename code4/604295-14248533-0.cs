    public class FractionLabel : Control
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }
        public Brush Brush { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var font = Font;
            var n = Numerator.ToString();
            var d = Denominator.ToString();
            var numSize = graphics.MeasureString(n, font);
            graphics.DrawString(n, Font, Brush, new PointF());
            //Comment out the following line if you want sharp lines
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(Brush))
            {
                var p1 = new PointF(numSize.Width/2, numSize.Height*5/4);
                var p2 = new PointF(numSize.Width*5/4, numSize.Height/2);
                graphics.DrawLine(pen, p1, p2);
            }
            var dPos = new PointF(numSize.Width*3/4, numSize.Height*3/4);
            graphics.DrawString(d, Font, Brush, dPos);
        }
    }
