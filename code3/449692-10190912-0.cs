        private bool mousePressed { get; set; }
        private bool mouseWithinArea { get; set; }
        private Point circleMiddlePoint { get; set; }
        private int margin;
        private double mPX;
        private double mPY;
        private double localXpos;
        private double globalXpos
        {
            get
            {
                return localXpos + mPX;
            }
            set
            {
                localXpos = value - mPX;
                Canvas.SetLeft(thumb, value);
            }
        }
        private double localYpos;
        private double globalYpos
        {
            get
            {
                return mPY - localYpos;
            }
            set
            {
                localYpos = mPY - value;
                Canvas.SetTop(thumb, value);
            }
        }
        public HSVColorPicker()
        {
            InitializeComponent();
            wheel.Width = 300;
            margin = 15;
            mPX = 150+margin;
            mPY = 150+margin;
            circleMiddlePoint = new Point(mPX, mPY);
        }
        private void CalcPosition(double X, double Y)
        {
            double radius = wheel.Width / 2.0;
            double vectorX = X - mPX;
            double vectorY = Y - mPY;
            double distance = Math.Sqrt(vectorX * vectorX + vectorY * vectorY);
            if (distance > radius)
            {
                double factor = radius / distance;
                vectorX *= factor;
                vectorY *= factor;
            }
            globalXpos = vectorX + mPX;
            globalYpos = vectorY + mPY;
        }
        private void wheel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (mouseWithinArea)
            {
                mousePressed = true;
                Point mousePoint = e.GetPosition(this);
                CalcPosition(mousePoint.X, mousePoint.Y);
            }
        }
        private void wheel_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePoint = e.GetPosition(this);
            double relX = mousePoint.X - mPX;
            double relY = mPY - mousePoint.Y;
            if (mouseWithinArea)
            {
                if (Math.Sqrt(relX * relX + relY * relY) > 150+margin)
                {
                    mouseWithinArea = false;
                }
                else
                {
                    if (mousePressed)
                    {
                        CalcPosition(mousePoint.X, mousePoint.Y);
                    }
                }
            }
            else
            {
                if (Math.Sqrt(relX * relX + relY * relY) < 150+margin)
                {
                    mouseWithinArea = true;
                    if (mousePressed)
                    {
                        CalcPosition(mousePoint.X, mousePoint.Y);
                    }
                }
            }
        }
        private void wheel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mousePressed = false;
        }
    }
    <Canvas x:Name="canvas" Background="Transparent" MouseDown="wheel_MouseDown" MouseMove="wheel_MouseMove" MouseUp="wheel_MouseUp" Width="330" Height="330">
            <Image x:Name="wheel" Source="colorwheel.png" Width="300" Margin="15,15,0,0"  />
            <Ellipse Margin="0,0,0,0"
                    x:Name="outerEll"
                    Stroke="Silver"
                    StrokeThickness="15" 
                    Width="330"
                    Height="330"/>
            <Ellipse Name="thumb" Stroke="Black" Fill="Silver" Canvas.Left="150" Canvas.Top="150" Width="15" Height="15" Margin="-12" />
        </Canvas>
