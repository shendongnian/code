    public partial class Form1 : Form
    {
        Bitmap buffer;
        public Form1()
        {
            InitializeComponent();
            panel1.BorderStyle = BorderStyle.FixedSingle;
            buffer = new Bitmap(panel1.Width,panel1.Height);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(buffer))
            {
                //Do your graphcis stuff here, I just drew a rectangle.
                g.DrawRectangle(Pens.Red, 100, 100,100,100);
            }
            panel1.BackgroundImage = buffer;
        }
