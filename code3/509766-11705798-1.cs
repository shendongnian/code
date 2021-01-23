    public partial class Form1 : Form
    {
        bool showLines;
        public Form1()
        {
            InitializeComponent();
            showLines = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (showLines)
            {
                showLines = false;
                pictureBox1.Invalidate();
            }
            else
            {
                showLines = true;
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(showLines)
                e.Graphics.DrawLine(Pens.Purple, 0, 0, 100, 100);
        }
    }
