    public partial class Form2 : Form
    {
        private Rectangle mHoverRectangle = Rectangle.Empty;
        private const int HOVER_RECTANGLE_SIZE = 20;
        public Form2()
        {
            InitializeComponent();
 
            pictureBox.MouseMove += new MouseEventHandler(pictureBox_MouseMove);
            pictureBox.Paint += new PaintEventHandler(pictureBox_Paint);
            pictureBox.MouseLeave += new EventHandler(pictureBox_MouseLeave);
        }
        void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            mHoverRectangle = Rectangle.Empty;
        }
        void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (mHoverRectangle != Rectangle.Empty)
            {
                using (Brush b = new SolidBrush(Color.FromArgb(150, Color.White)))
                {
                    e.Graphics.FillRectangle(b, mHoverRectangle);
                }
            }
        }
        void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            mHoverRectangle = new Rectangle(
                e.Location.X - HOVER_RECTANGLE_SIZE / 2,
                e.Location.Y - HOVER_RECTANGLE_SIZE / 2,
                HOVER_RECTANGLE_SIZE,
                HOVER_RECTANGLE_SIZE);
            pictureBox.Invalidate();
        }
