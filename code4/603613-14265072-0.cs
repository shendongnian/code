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
						//---- Adding the image into TAG....
						myPicBox.Tag = images[aa];
						//---- :)
                        myPicBox.Image = new Bitmap(images[aa]);
						
                        this.flowLayoutPanel1.Controls.Add(myPicBox);
                        //myPicBox.Click += new EventHandler(curPb_Click);
                        //myPicBox.MouseUp += new MouseEventHandler(myPicBox_MouseUp);
                        myPicBox.MouseDown += new MouseEventHandler(myPicBox_MouseDown);
                        myPicBox.MouseLeave += new EventHandler(mmm_Leave);
                    }
    
    
            }
            //private PictureBox senderAsPictureBox = null;
            private void mmm_Leave(object sender, EventArgs e)
            {
                PictureBox senderAsPictureBox = sender as PictureBox;
                senderAsPictureBox.BackColor = Color.Empty;
            }
            private void myPicBox_MouseDown(object sender, MouseEventArgs e)
            {
                PictureBox senderAsPictureBox = sender as PictureBox;
				//------------ Printing the FULL PATH
                MessageBox.Show(senderAsPictureBox.Tag.ToString());
				//------------ 
                senderAsPictureBox.BackColor = Color.AliceBlue;
            }
