        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
            Center = new PointF((float)pBox1.Width / 2, (float)pBox1.Height / 2);
            MillisecondLength = (float)pBox1.Width / 4;  //length of millisecond hand
            timer1.Interval = 10;  
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
        }
        PointF Center;
        float MillisecondLength;
        Pen MillisecondsPen = new Pen(Brushes.Blue, (float)3);
        double HALF_PI = Math.PI / 2;
        double TWO_PI = 2 * Math.PI;
        double millisecondHandAngle(DateTime dt)
        {
            //12 o'clock is at the top! (- PI / 2)
            return TWO_PI * dt.Millisecond / 1000 - HALF_PI;
        }
        void pBox1_Paint(object sender, PaintEventArgs e)
        {
            DateTime dt = DateTime.Now;         
            double mangle = millisecondHandAngle(dt);
            SizeF millisecondOffset = new SizeF(
                (float)(MillisecondLength * Math.Cos(mangle)), 
                (float)(MillisecondLength * Math.Sin(mangle))
            );
            PointF endMillisecond = PointF.Add(Center, millisecondOffset);
            e.Graphics.DrawLine(MillisecondsPen, Center, endMillisecond);
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            pBox1.Invalidate();
        }
