    class RotatingPictureBox : PictureBox
    {
        public double Angle { get; set; }
        public double Speed { get; set; }
        public double Distance { get; set; }
        public void RotateStep()
        {
            var oldX = Math.Cos(Angle)*Distance;
            var oldY = Math.Sin(Angle)*Distance;
            Angle += Speed;
            var x = Math.Cos(Angle)*Distance - oldX;
            var y = Math.Sin(Angle)*Distance - oldY;
            Location += new Size(new Point((int) x, (int) y));
        }
    }
