        BackgroundWorker bw;
        Image img;
        private void Form1_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerAsync();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (img != null)
            {
                e.Graphics.DrawImage(img, 10, 10, 55, 55);
            }
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            WebRequest aReq = WebRequest.Create(avatarURL);
            WebResponse aRes = aReq.GetResponse();
            img = Image.FromStream(aRes.GetResponseStream());
        }
