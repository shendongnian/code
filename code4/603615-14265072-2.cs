       private void button1_Click(object sender, EventArgs e)
        {
     string theimage = AppDomain.CurrentDomain.BaseDirectory + @"allimages";
     string[] images = Directory.GetFiles(theimage, "*.png");
                    int aa;
                      for (aa = 1; aa < images.Count(); aa++)
                {
                    PictureBox myPicBox = new PictureBox();
                    myPicBox.Location = new Point(7, 240);
                    myPicBox.Width = 100;
                    myPicBox.Height = 77;
                    myPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                    myPicBox.Margin = new Padding(3, 3, 3, 3);
                    myPicBox.Visible = true;
                    FileStream fs = new FileStream(images[aa], FileMode.Open, FileAccess.Read);
                    myPicBox.Image = Image.FromStream(fs);
                    myPicBox.Name = images[aa];
                    fs.Close();
                    this.flowLayoutPanel1.Controls.Add(myPicBox);
                    //myPicBox.Click += new EventHandler(curPb_Click);
                    //myPicBox.MouseUp += new MouseEventHandler(myPicBox_MouseUp);
                    myPicBox.MouseDown += new MouseEventHandler(myPicBox_MouseDown);
                    myPicBox.MouseLeave += new EventHandler(mmm_Leave);
                    myPicBox.PreviewKeyDown += new PreviewKeyDownEventHandler(myPicBox_PreviewKeyDown);
                    
                }
    
    
            }
            private void myPicBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox senderAsPictureBox = sender as PictureBox;
            senderAsPictureBox.Focus(); // binding for clicking
            senderAsPictureBox.BackColor = Color.AliceBlue;
        }
        void myPicBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            PictureBox senderAsPictureBox = sender as PictureBox;
            if (e.KeyCode == Keys.Delete)
                senderAsPictureBox.Image = null;
                senderAsPictureBox.Invalidate();
                senderAsPictureBox.Dispose();
                File.Delete(senderAsPictureBox.Name);
        }
