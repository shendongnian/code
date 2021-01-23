    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point locationClicked;
        bool dragForm = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                locationClicked = new Point(e.Location.X, e.Location.Y);
                if (isMouseDown && targetCell == new Point(-1, -1) && (mouseLocation.X < margin.X || mouseLocation.Y < margin.Y ||
                    mouseLocation.X > margin.X + cellSize.Width * gridSize.Width ||
                    mouseLocation.Y > margin.Y + cellSize.Height * gridSize.Height))
                {
                    dragForm = true;
                }
            }
            
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragForm)
            {
                this.Location = new Point(this.Location.X + (e.X - locationClicked.X), this.Location.Y + (e.Y - locationClicked.Y));
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragForm = false;
        }
    }
