    public partial class Form1 : Form
    {
        Random r = new Random(DateTime.Now.Millisecond);
        List<Pixel> pixels = new List<Pixel>();
        public Form1()
        {            
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int ii = 0; ii < 5; ii++)
            {
                pixels.Add(new Pixel(pictureBox1, r));
            }
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Pixel p in pixels)
                p.Draw(e, pictureBox1);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
    }
    public class Pixel
    {
        public Point Position { get; set; }
        public Pixel(PictureBox src, Random r) 
        {
            Position = new Point(r.Next(0, src.Width), r.Next(0, src.Height));
        }
        public void Draw(PaintEventArgs e, PictureBox src)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black), Position.X, Position.Y, 1, 1);
        }
    }
