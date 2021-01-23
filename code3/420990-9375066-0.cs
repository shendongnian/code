    public partial class Photo : Form
        {
            public delegate void ScreenShotReadyDelegate(Bitmap g);
            public event ScreenShotReadyDelegate ScreenShotReady;
    
            bool Moving = false;
            Point oldLoc = new Point();
    
            public Photo()
            {
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.ResizeRedraw, true);
            } 
    
            private void Photo_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                this.BackgroundImage = null;
                this.Invalidate();
                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }
                    ScreenShotReady(bitmap);
                }
                this.BackgroundImage = Properties.Resources.rect;
                this.Invalidate();
            }
    
            private void Photo_MouseDown(object sender, MouseEventArgs e)
            {
                this.Moving = true;
                this.oldLoc = MousePosition;
            }
    
            private void Photo_MouseMove(object sender, MouseEventArgs e)
            {
                if (this.Moving)
                {
                    Point vector = new Point(MousePosition.X - this.oldLoc.X, MousePosition.Y - this.oldLoc.Y);
                    this.Location = new Point(this.Location.X + vector.X, this.Location.Y + vector.Y);
                    this.oldLoc = MousePosition;
                }
            }
    
            private void Photo_MouseUp(object sender, MouseEventArgs e)
            {
                this.Moving = false;
            }
        }
