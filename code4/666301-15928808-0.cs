        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(PictureBox.Width, PictureBox.Height);
            AngleValueTextBox_TextChanged(null, null); // Why doesn't this make the box appear on program start?
            PictureBox.Invalidate();  // Or this?
        }
        public class CircleCenterClass
        {
            public double X; public double Y;
            public CircleCenterClass(double X, double Y) { this.X = X; this.Y = Y; }
        }
        CircleCenterClass GetCenterOfOrbitCircle(CircleCenterClass OrbitCenter, double OrbitRadius, double Angle)
        {
            CircleCenterClass Result = new CircleCenterClass(0, 0);
            Result.X = OrbitCenter.X + OrbitRadius * Math.Sin(Angle * (3.141592654 / 180));
            Result.Y = OrbitCenter.Y - OrbitRadius * Math.Cos(Angle * (3.141592654 / 180));
            return Result;
        }
        private void drawPictureBox(Graphics graphics, bool ownGraphics)
        {
        }
        private void DrawImage()
        {
            double Angle = 0;
            // Normally this is an expensive hardware call which I don't want to make more than 
            // once a second.
            try
            {
                Double.TryParse(AngleValueTextBox.Text, out Angle);
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not parse Angle " +
                                 AngleValueTextBox.Text);
            }
            using (Graphics gx = Graphics.FromImage(bitmap))
            {
                gx.Clear(BackColor);
                double OrbitedCircleRadius = 40;
                CircleCenterClass OrbitedCircleCenter = new CircleCenterClass(60, 60);
                double OrbitingCircleRadius = 7;
                Pen MyRedPen = new Pen(Color.Red, 2f);
                Brush MyBlackBrush = new SolidBrush(Color.Black);
                gx.DrawEllipse(MyRedPen, (Int32)(OrbitedCircleCenter.X - OrbitedCircleRadius),
                                                (Int32)(OrbitedCircleCenter.Y - OrbitedCircleRadius),
                                                (Int32)(2 * OrbitedCircleRadius),
                                                (Int32)(2 * OrbitedCircleRadius));
                CircleCenterClass CircleCenter = GetCenterOfOrbitCircle(
                                    OrbitedCircleCenter, OrbitedCircleRadius,
                                    Angle);
                gx.FillEllipse(MyBlackBrush, (Int32)(CircleCenter.X - OrbitingCircleRadius),
                                             (Int32)(CircleCenter.Y - OrbitingCircleRadius),
                                             (Int32)(2 * OrbitingCircleRadius),
                                             (Int32)(2 * OrbitingCircleRadius));
            }
        }
        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
        private void AngleValueTextBox_TextChanged(object sender, EventArgs e)
        {
            DrawImage();
            PictureBox.Invalidate();
        }
