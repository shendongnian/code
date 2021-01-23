        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);
        }
        void  pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                int width = pictureBox1.Image.Width;
                int height = pictureBox1.Image.Height;
                e.Graphics.DrawLine(crosshairPen, new Point(width / 2, 0), new Point(width / 2, height));
                e.Graphics.DrawLine(crosshairPen, new Point(0, pictureBox1.Image.Height / 2), new Point(width, height / 2));
                e.Graphics.DrawEllipse(crosshairPen, (width / 2) - crosshairRadius, (height / 2) - crosshairRadius, crosshairRadius * 2, crosshairRadius * 2);
            }
        } 
        IAsyncResult result = null;
        void CurrentCamera_ImageUpdated(object sender, EventArgs e)
        {
            try
            {
                lock (CurrentCamera.image)
                {
                    if (CurrentCamera != null && CurrentCamera.image != null && !changeCam)
                    {
                        videoImage = CurrentCamera.videoImage;
                        if (CurrentCamera.videoImage != null && this.IsHandleCreated)
                        {
                            if (result != null && result.IsCompleted)
                            {
                                result = pictureBox1.BeginInvoke((MethodInvoker)delegate
                                {
                                    pictureBox1.Image = CurrentCamera.videoImage;
                                });
                            }
                        }
                    }
                }
            }
            catch { }
        }
