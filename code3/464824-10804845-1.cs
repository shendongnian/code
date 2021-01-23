     public Form1()
        {
            InitializeComponent();
        }
        Panel[,] pb = new Panel[9, 9];
        private void Form1_Load(object sender, EventArgs e)
        {
           //this is just to add the panels to the screen.  
           //We are using panels to simulate zoomed in pixels so we can see what is going on
            for (int y = 0; y < 9; y++)
                for (int x = 0; x < 9; x++)
                {
                    pb[x, y] = new Panel();
                    pb[x, y].BackColor = Color.MistyRose;
                    pb[x, y].BorderStyle = BorderStyle.FixedSingle;
                    pb[x, y].Size = new Size(20, 20);
                    pb[x, y].Location = new Point(x * 20, y * 20);
                    this.Controls.Add(pb[x,y]);
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DrawPixel(new Point(4, 4), (int)numericUpDown1.Value,trackBar1.Value+1);
        }
        public void DrawPixel(Point pixel, int radius,int intensity)
        {
            radius--;
            for (int y = 0; y <= 8; y++)
                for (int x = 0; x <= 8; x++)
                {
                    //clears the screen before starting
                    pb[x, y].BackColor = Color.White;
                    //calculate the distance from the center pixel
                    double Distance = Math.Sqrt( ((x-pixel.X)*(x-pixel.X) + (y-pixel.Y) *(y-pixel.Y))-radius*radius );
                    //determine color intensity
                    int alpha = (int)Distance <= 0 ? 255 : (int)Distance > intensity ? 0 : (int)(intensity - Distance) * 50 > 255 ? 255 : (int)(intensity - Distance) * 50;
                    
                    if (alpha>0)
                        pb[x, y].BackColor = Color.FromArgb(alpha, Color.Red);
                }
        }
