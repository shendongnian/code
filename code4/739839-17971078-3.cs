    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
            //To prevent/eliminate flicker, do this
            typeof(Panel).GetProperty("DoubleBuffered", 
                                      System.Reflection.BindingFlags.Instance | 
                   System.Reflection.BindingFlags.NonPublic).SetValue(panel1, true, null);
            //------------------------
            UpdateScrollbarsState();
        }        
        int imgWidth, imgHeight;
        Image image;
        Point leftTop = Point.Empty;
        int lastV, lastH;
        private void OpenImage(){
            OpenFileDialog openFile = new OpenFileDialog();            
            openFile.FileOk += (s, e) => {
                try {
                    image = Image.FromFile(openFile.FileName);
                    //calculate the physical size of the image based on the resolution and its logical size.
                    //We have to do this because the DrawImage is based on the physical size (not logical).
                    imgWidth = (int)(image.Width * 96f / image.HorizontalResolution + 0.5);
                    imgHeight = (int)(image.Height * 96f / image.VerticalResolution + 0.5);
                    lastV = lastH = 0;
                    UpdateScrollbarsState();
                    vScrollBar1.Value = 0;
                    hScrollBar1.Value = 0;
                    panel1.Invalidate();
                }
                catch {
                    image = null;
                    MessageBox.Show("Image file is invalid or corrupted!");
                }
            };
            openFile.ShowDialog();
        }
        private void UpdateScrollbarsState() {
            //We have to update all the info about Minimum and Maximum
            vScrollBar1.Minimum = 0;
            hScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = Math.Max(imgHeight-panel1.Height,0);
            hScrollBar1.Maximum = Math.Max(imgWidth-panel1.Width,0);
            vScrollBar1.Visible = vScrollBar1.Maximum > 0;
            hScrollBar1.Visible = hScrollBar1.Maximum > 0;
            if (vScrollBar1.Maximum == 0) {
                leftTop.Y = 0;
                lastV = 0;
            }
            if (hScrollBar1.Maximum == 0) {
                leftTop.X = 0;
                lastH = 0;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e) {
            if (image == null) return;
            e.Graphics.DrawImage(image, leftTop);
        }
        //The ValueChanged event handler of your vScrollBar1
        private void vScrollBar1_ValueChanged(object sender, EventArgs e) {
            if (!vScrollBar1.Visible) return;
            leftTop.Offset(0, -vScrollBar1.Value + lastV);
            lastV = vScrollBar1.Value;
            panel1.Invalidate();
        }
        //The ValueChanged event handler of your hScrollBar1
        private void hScrollBar1_ValueChanged(object sender, EventArgs e) {
            if (!hScrollBar1.Visible) return;
            leftTop.Offset(lastH - hScrollBar1.Value, 0);
            lastH = hScrollBar1.Value;
            panel1.Invalidate();
        }
        //handler for SizeChanged event of the panel. However if resizing
        //the form causes the panel's size changing, you should attach this 
        //handler for form.
        private void panel1_SizeChanged(object sender, EventArgs e) {
            UpdateScrollbarsState();
        }
        //handler for the Click event of a button (click to open an image)
        private void buttonOpenImage_Click(object sender, EventArgs e) {
            OpenImage();
        }
    }
