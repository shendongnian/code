        PictureBox pb = new PictureBox();
        public Form6()
        {
            InitializeComponent();
            pb.Image = WindowsFormsApplication1.Properties.Resources.loading7;
            pb.Visible = false;
            pb.Width = pb.Image.Width;
            pb.Height = pb.Image.Height;
            this.Controls.Add(pb);
        }
        
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress < e.MaximumProgress)
            {
                if (!pb.Visible)
                {
                    int x = webBrowser1.Left + ((webBrowser1.Width - pb.Width) / 2);
                    int y = webBrowser1.Top + ((webBrowser1.Height - pb.Height) / 2);
                    pb.Location = new Point(x, y);
                    pb.BringToFront();
                    pb.Visible = true;
                }
            }
            else
            {
                pb.Visible = false;
            }
        }
