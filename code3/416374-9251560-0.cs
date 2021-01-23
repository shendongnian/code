        private bool isPressed = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.B && !isPressed )
            {
                isPressed = true;
                // do work
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isPressed )
                isPressed = false;
        }
