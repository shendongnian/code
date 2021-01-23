     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                tm.Interval = 100;
                tm.Tick += new EventHandler(tm_Tick);
                tm.Start();
            }
            Timer tm = new Timer();
            void tm_Tick(object sender, EventArgs e)
            {
                pictureBox1.Location = new Point((int)(new Random().Next(0, 1025)), (int)(new Random().Next(0, 545)));
            }
            
        }
