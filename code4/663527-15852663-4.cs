    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                tm.Interval = 1000;
                tm.Tick += new EventHandler(tm_Tick);
                tm.Start();
            }
            Timer tm = new Timer();
            int X = 0;
            int Y = 0;
            void tm_Tick(object sender, EventArgs e)
            {
                X = ((int)(new Random().Next(0, 1025)));
                Y = ((int)(new Random().Next(0, 545)));
                if (X > 1025 - pictureBox1.Width)
                {
                    X = 1025 - pictureBox1.Width;
                }
                if (Y > 545 - pictureBox1.Height)
                {
                    Y = 545 - pictureBox1.Height;
                }
                pictureBox1.Location = new Point(X, Y);
            }
            
        }
