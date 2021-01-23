    public Form1()
    {
        InitializeComponent();
        this.Paint += new System.Windows.Forms.PaintEventHandler(Form1_Paint);
        Main_PictureBox.Paint += new PaintEventHandler(Main_PictureBox_Paint);
        Main_PictureBox.MouseDown += new MouseEventHandler(StartZoom);
        Zoom_PictureBox.MouseDown += new MouseEventHandler(StartZoom);
        Main_PictureBox.MouseMove += new MouseEventHandler(MoveZoom);
        Main_PictureBox.MouseUp += new MouseEventHandler(EndZoom);
        Main_PictureBox.MouseLeave += new EventHandler(EndZoom);
        Zoom_PictureBox.MouseUp += new MouseEventHandler(EndZoom);
        Zoom_PictureBox.VisibleChanged += new EventHandler(Zoom_PictureBox_VisibleRegion);
        Zoom_PictureBox.Paint += new PaintEventHandler(Zoom_PictureBox_Paint);
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        int H = flowLayoutPanel1.Height - flowLayoutPanel1.Margin.Size.Height;
        Main_PictureBox.MinimumSize = new Size(0, 0);
        Main_PictureBox.MaximumSize = new Size(flowLayoutPanel1.Width, H);
    }
    private void Main_PictureBox_Paint(object sender, PaintEventArgs e)
    {
        Main_PictureBox.Parent.MaximumSize = Main_PictureBox.Size + Main_PictureBox.Margin.Size;
    }
    private void DisplayImage(object sender, EventArgs e)
    {
        Image img = ((PictureBox)sender).Image;
        int W = img.Width;
        int H = img.Height;
        float ratio = (float)W / (float)H;
        Main_PictureBox.Image = img;
        Main_PictureBox.Size = new Size(W, H);
        float TestRatio = ((float)Main_PictureBox.Width / (float)Main_PictureBox.Height);
        if (TestRatio < ratio)
            Main_PictureBox.Height = (int)((float)Main_PictureBox.Width / ratio);
        else if (TestRatio > ratio)
            Main_PictureBox.Width = (int)((float)Main_PictureBox.Height * ratio);
    }
    private void Zoom_PictureBox_VisibleRegion(object sender, EventArgs e)
    {
        using (var gp = new System.Drawing.Drawing2D.GraphicsPath())
        {
            gp.AddEllipse(new Rectangle(0, 0, this.Zoom_PictureBox.Width, this.Zoom_PictureBox.Height));
            this.Zoom_PictureBox.Region = new Region(gp);
        }
    }
    private void Zoom_PictureBox_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.DrawImage(Main_PictureBox.Image, e.ClipRectangle, cropRectangle, GraphicsUnit.Pixel);
    }
    private void StartZoom(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left && scale > 1.25)
        {
            int dX = Zoom_PictureBox.Width / 2;
            int dY = Zoom_PictureBox.Height / 2;
            Zoom_PictureBox.Visible = true;
            Zoom_PictureBox.Location = new Point(e.X - dX, e.Y - dY);
        }
    }
    private void MoveZoom(object sender, MouseEventArgs e)
    {
        if (Main_PictureBox.Image != null)
        {
            Zoom_PictureBox.Visible = (e.Button == MouseButtons.Left && scale > 1.25);
            if (Zoom_PictureBox.Visible && e.Button == MouseButtons.Left)
            {
                int dX = Zoom_PictureBox.Width / 2;
                int dY = Zoom_PictureBox.Height / 2;
                Zoom_PictureBox.Location = new Point(e.X - dX, e.Y - dY);
                Zoom_PictureBox.Invalidate();
            }
        }
    }
    private void EndZoom(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            EndZoom();
    }
    private void EndZoom(object sender, EventArgs e)
    {
        EndZoom();
    }
    private void EndZoom()
    {
        Zoom_PictureBox.Visible = false;
    }
    private Rectangle cropRectangle
    {
        get
        {
            if (Main_PictureBox.Image != null)
            {
                Point origin = Main_PictureBox.PointToScreen(new Point(0, 0));
                float X = (float)(MousePosition.X - origin.X);
                return new Rectangle(
                    (int)(scale * X) - Zoom_PictureBox.Width / 2,
                    (int)(scale * (float)(MousePosition.Y - origin.Y)) - Zoom_PictureBox.Height / 2,
                    Zoom_PictureBox.Width,
                    Zoom_PictureBox.Height);
            }
            else
                return new Rectangle();
        }
    }
    private float scale
    {
        get
        {
            if (Main_PictureBox.Image != null)
                return (float)Main_PictureBox.Image.Height / (float)Main_PictureBox.Height;
            else
                return 0;
        }
    }
