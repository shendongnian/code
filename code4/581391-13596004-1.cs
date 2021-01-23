    public partial class Form1 : Form
    {
        public List<Rectangle> listRec = new List<Rectangle>();
        Graphics g;
        
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
                g = pictureBox1.CreateGraphics();
                Pen p = new Pen(Color.Blue);
                g.DrawRectangle(p, rec);
            }
        }
        public void ChangeColor(Rectangle target, Color targetColor)
        {
            Pen p = new Pen(targetColor);
            g.DrawRectangle(p, target.X, target.Y, target.Width, target.Height);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0: ChangeColor(listRec[0], Color.Red);
                    break;
                case Keys.D1: ChangeColor(listRec[1], Color.Red);
                    break;
                //..more code to handle all keys..
            }
        }    
    }
