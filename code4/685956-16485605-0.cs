    public partial class Form1 : Form
    {
        private Rectangle r;
        private const int rSize = 50;
        private const int move_x = 10;
        private System.Windows.Forms.Timer tmr;
        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.Black;
            r = new Rectangle(0, panel1.Height / 2 - rSize / 2, rSize, rSize);
            tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 50;
            tmr.Tick += new EventHandler(tmr_Tick);
            tmr.Start();
            panel1.Paint += new PaintEventHandler(panel1_Paint);
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            r.X += move_x;
            panel1.Refresh();
            if (r.X > panel1.Width)
            {
                tmr.Stop();
                MessageBox.Show("Done");
            }
        }
        void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.White, r);
        }
    }
