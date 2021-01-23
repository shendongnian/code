    public Form1()
        {
            InitializeComponent();
        }
        Panel[,] pb = new Panel[9, 9];
        private void Form1_Load(object sender, EventArgs e)
        {
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
            DrawPixel(new Point(4, 4), (int)numericUpDown1.Value);
        }
        public void DrawPixel(Point pixel, int radius)
        {
            for (int y = pixel.Y - radius; y <= pixel.Y + radius; y++)
                for (int x = pixel.X - radius; x <= pixel.Y + radius; x++)
                {
                    int deltax = x > pixel.X ? x - pixel.X : pixel.X - x;
                    int deltay = y > pixel.Y ? y - pixel.Y : pixel.Y - y;
                    if (deltax + deltay <= radius)
                    {
                       if (deltax + deltay == 0)
                            pb[x, y].BackColor = Color.Red;
                        else if (deltax + deltay == 1)
                            pb[x, y].BackColor = Color.FromArgb(200, Color.Red);
                        else if (deltax + deltay == 2)
                            pb[x, y].BackColor = Color.FromArgb(150, Color.Red);
                        else if (deltax + deltay == 3)
                            pb[x, y].BackColor = Color.FromArgb(100, Color.Red);
                        else if (deltax + deltay == 4)
                            pb[x, y].BackColor = Color.FromArgb(50, Color.Red);
                    }
                }
        }
