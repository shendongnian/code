        public Exercise1()
        {
            InitializeComponent();
        
            balloon = new Balloon("redBalloon", Color.Red, drawingArea.Width / 2, 
            drawingArea.Height / 2, 30);
    
    
            drawingArea.Paint += new PaintEventHandler(drawingArea_Paint);
        }
        void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            baloon.Display(e.Graphics);
        }
