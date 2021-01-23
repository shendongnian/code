        private const int ACCELERATION = 1;
        private HashSet<Keys> pressed;
        private int velocityX = 0;
        private int velocityY = 0;
        public Form1()
        {
            InitializeComponent();
            pressed = new HashSet<Keys>();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressed.Add(e.KeyCode);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressed.Remove(e.KeyCode);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            car.Location = new Point(
                car.Left + velocityX,
                car.Top + velocityY);
            if (pressed.Contains(Keys.W)) velocityY -= ACCELERATION;
            if (pressed.Contains(Keys.A)) velocityX -= ACCELERATION;
            if (pressed.Contains(Keys.S)) velocityY += ACCELERATION;
            if (pressed.Contains(Keys.D)) velocityX += ACCELERATION;
        }
