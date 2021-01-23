    public partial class Exitform : Form
    {
        private const int CpNocloseButton = 0x200;
        private bool mouseIsDown = false;
        private Point firstPoint;
        public event EventHandler OnTrackBarValueChanged;
        public Exitform()
        {
            InitializeComponent();
            this.TopMost = false;
        }
        public int TrackBarValue
        {
            get
            {
                return contrast_trackbar.Value;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CpNocloseButton;
                return myCp;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            mouseIsDown = true;
            //http://stackoverflow.com/questions/3441762/how-can-i-move-windows-when-mouse-down
        }
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                // Get the difference between the two points
                int xDiff = firstPoint.X - e.Location.X;
                int yDiff = firstPoint.Y - e.Location.Y;
                // Set the new point
                int x = this.Location.X - xDiff;
                int y = this.Location.Y - yDiff;
                this.Location = new Point(x, y);
            }
        }
        private void contrast_trackbar_Scroll(object sender, EventArgs e)
        {
            OnTrackBarValueChanged(this, EventArgs.Empty);
        }
    }
