    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            const int gridSpacing = 20;
            const int lineThickness = 1;
            Bitmap bmp = new Bitmap(gridSpacing, gridSpacing);
            using (System.Drawing.Pen pen = new System.Drawing.Pen(Color.Blue, lineThickness))
            {
                using (Graphics G = Graphics.FromImage(bmp))
                {
                    G.Clear(this.BackColor);
                    G.DrawLine(pen, 0, bmp.Height - pen.Width, bmp.Width, bmp.Height - pen.Width); // horizontal
                    G.DrawLine(pen, bmp.Width - pen.Width, 0, bmp.Width - pen.Width, bmp.Height); // vertical
                }
            }
            foreach (TabPage TP in tabControl1.TabPages)
            {
                TP.BackgroundImage = bmp;
                TP.BackgroundImageLayout = ImageLayout.Tile;
            }
        }
    }
