    private Bitmap image;
    private Bitmap newImage;
    private Rectangle imageRegion;
    private PictureBox pbImageRegion;
    private Point clickedPointOne;
    private Point clickedPointTwo;
    private bool allowMouseMove;
    private bool clickedCutButton;
    private bool firstClick;
    public Form1()
    {
        InitializeComponent();
        mainPictureBox.BackColor = Color.White;
        secondPictureBox.BackColor = Color.White;
    }
    private void loadImageButton_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            image = new Bitmap(ofd.FileName);
            mainPictureBox.Image = image;
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(new Point(0, 0), secondPictureBox.Size));
            secondPictureBox.Image = bmp;
        }
    }
    private void cutImageButton_Click(object sender, EventArgs e)
    {
        firstClick = false;
        clickedCutButton = true;
        allowMouseMove = false;
        pbImageRegion = new PictureBox();
        pbImageRegion.BackColor = Color.Transparent;
        pbImageRegion.BorderStyle = BorderStyle.FixedSingle;
        pbImageRegion.Size = new Size(0, 0);
        pbImageRegion.MouseMove += new MouseEventHandler(pbImageRegion_MouseMove);
    }
    void pbImageRegion_MouseMove(object sender, MouseEventArgs e)
    {
        if (allowMouseMove == true)
            pbImageRegion.Size = new Size(Math.Abs(e.X - clickedPointOne.X - 2), Math.Abs(e.Y - clickedPointOne.Y - 2));
    }
    private void mainPictureBox_MouseClick(object sender, MouseEventArgs e)
    {
        if (clickedCutButton == true)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (firstClick == false)
                {
                    pbImageRegion.Location = new Point(e.X, e.Y);
                    mainPictureBox.Controls.Add(pbImageRegion);
                    clickedPointOne = new Point(e.X, e.Y);
                    allowMouseMove = true;
                    firstClick = true;
                }
                else
                {
                    imageRegion = new Rectangle(clickedPointOne, pbImageRegion.Size);
                    newImage = image.Clone(imageRegion, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    allowMouseMove = false;
                    mainPictureBox.Invalidate();
                }
            }
        }
    }
    private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
    {
        //It works only from left to right
        if (allowMouseMove == true)
            pbImageRegion.Size = new Size(Math.Abs(e.X - clickedPointOne.X - 2), Math.Abs(e.Y - clickedPointOne.Y - 2));
    }
    private void secondPictureBox_MouseClick(object sender, MouseEventArgs e)
    {
        if (clickedCutButton == true)
        {
            if (e.Button == MouseButtons.Left)
            {
                clickedCutButton = false;
                pbImageRegion.Size = new Size(0, 0);
                clickedPointTwo = new Point(e.X, e.Y);
                secondPictureBox.Invalidate();
            }
        }
    }
    private void secondPictureBox_Paint(object sender, PaintEventArgs e)
    {
        if (newImage != null)
        {
            Graphics g = Graphics.FromImage(secondPictureBox.Image);
            g.DrawImage(newImage, clickedPointTwo);
            e.Graphics.DrawImage(secondPictureBox.Image, new Point(0, 0));
        }
    }
    private void mainPictureBox_Paint(object sender, PaintEventArgs e)
    {
        if (newImage != null && allowMouseMove == false)
        {
            Bitmap bmp = new Bitmap(newImage.Width, newImage.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(mainPictureBox.BackColor), new Rectangle(new Point(0, 0), newImage.Size));
            g = Graphics.FromImage(image);
            g.DrawImage(bmp, clickedPointOne);
        }
    }
