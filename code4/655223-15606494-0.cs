    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("X: {0}, Y: {1}", e.X, e.Y);
    
            if (e.X >= 0 && e.X <= 200)
            {
                if (e.Y >= 0 && e.Y <= 200)
                {
                    SetCursorPos(500, 500);
                }
            }
        }
    
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = string.Format("X: {0}, Y: {1}", e.X, e.Y);
    
            if (e.X >= 0 && e.X <= 200)
            {
                if (e.Y >= 0 && e.Y <= 200)
                {
                    SetCursorPos(500, 500);
                }
            }
        }
    }
