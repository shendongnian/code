    public partial class Form1 : Form
    {
        public const int FIBNUM = 8;
        public const int CENTERX = 300;
        public const int CENTERY = 300;
        public const int ZOOM = 10;
        public Form1()
        {
            InitializeComponent();
            drawSpiral();
        }
        private int fib(int n, int p = 0, int q = 1)
        {
            switch (n)
            {
                case 0: return 0;
                case 1: return q;
                default: return fib(n - 1, q, p + q);
            }
        }
        private void drawSpiral()
        {
            if (pictureBox1.Image == null)
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                Rectangle r = new Rectangle(0, 0, 0, 0);
                int x = CENTERX;
                int y = CENTERY;
                for (int n = 1; n <= FIBNUM; n++)
                {
                    int fibnum = fib(n)*ZOOM;
                    r = new Rectangle(x, y, fibnum, fibnum);
                    g.DrawRectangle(Pens.Red, r);
                    switch (n % 4)
                    {
                        case 0:
                            {
                                y += fibnum;
                                break;
                            }
                        case 1:
                            {
                                x += fibnum;
                                y -= fib(n - 1) * ZOOM;
                                break;
                            }
                        case 2:
                            {
                                x -= fib(n - 1)*ZOOM;
                                y -= fib(n + 1)*ZOOM;
                                break;
                            }
                        case 3:
                            {
                                x -= fib(n + 1) * ZOOM;
                                break;
                            }
                    }
                }
                pictureBox1.Invalidate();
            }
        }
    }
