    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            static int imgCounter = 0;//keeps track of img for naming
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                CaptureScreen();
            } 
            private void tempPictureBox_Click(object sender, EventArgs e)
            {
                //Put code here
            }
            private void CaptureScreen()
            {
                /*This method captures a snapshot of screen and 
                 * adds it to the ImageFlowLayoutPanel
                 */
                Rectangle bounds = Screen.GetBounds(Point.Empty);
                Bitmap bmp = new Bitmap(bounds.Width, bounds.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                imgCounter += 1;
                bmp.Save("snap" + imgCounter.ToString() + ".jpg", ImageFormat.Jpeg);
                //creating a picturebox control and add it to the flowlayoutpanel
                PictureBox tempPictureBox = new PictureBox();
                //generates a thumbnail image of specified size
                tempPictureBox.Image = bmp.GetThumbnailImage(100, 100,
                                   new Image.GetThumbnailImageAbort(ThumbnailCallback),
                                   IntPtr.Zero);
                tempPictureBox.Size = new System.Drawing.Size(100, 100);
                tempPictureBox.Click += new System.EventHandler(this.tempPictureBox_Click);
                tempPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
                flowLayoutPanel1.Controls.Add(tempPictureBox);
            }
            public bool ThumbnailCallback()
            {
                return true;
            }
        }
    }
