    public partial class Form1 : Form
    {
        public List<Rectangle> listRec = new List<Rectangle>();
        
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Rectangle rect = new Rectangle();
            rect.Size = new Size(100,20);
            for (int x = 0; x < 5; x++)
            {
                rect.X = x * rect.Width;
                for (int y = 0; y < 5; y++)
                {
                    rect.Y = y * rect.Height;
                    listRec.Add(rect);
                }
            }
            foreach (Rectangle rec in listRec)
            {
                Graphics g = pictureBox1.CreateGraphics();
                Pen p = new Pen(Color.Blue);
                g.DrawRectangle(p, rec);
            }
        }
    }
