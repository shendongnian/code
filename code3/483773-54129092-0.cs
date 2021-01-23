       private int xUp, yUp, xDown,yDown;
            private Rectangle rectCropArea;
       private void SrcPicBox_MouseUp(object sender, MouseEventArgs e)
            {
                //pictureBox1.Image.Clone();
                xUp = e.X;
                yUp = e.Y;
                Rectangle rec = new Rectangle(xDown,yDown,Math.Abs(xUp xDown),Math.Abs(yUp-yDown));
                using (Pen pen = new Pen(Color.YellowGreen, 3))
                {
    
                    SrcPicBox.CreateGraphics().DrawRectangle(pen, rec);
                }
                rectCropArea = rec;
            }
     private void SrcPicBox_MouseDown(object sender, MouseEventArgs e)
            {
                SrcPicBox.Invalidate();
    
                xDown = e.X;
                yDown = e.Y;
            }
     private void btn_upload_Click(object sender, EventArgs e)
            {
                OpenFileDialog opf = new OpenFileDialog();
              //  PictureBox SrcPicBox = new PictureBox();
                opf.Filter = "ALL images(*.*)|*.*";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    string name = opf.SafeFileName;
                    string filepath = opf.FileName;
                    File.Copy(filepath, name, true);
                    SrcPicBox.Image = Image.FromFile(opf.FileName);
                }
     private void btn_crop_Click(object sender, EventArgs e)
            {
                pictureBox3.Refresh();
                //Prepare a new Bitmap on which the cropped image will be drawn
                Bitmap sourceBitmap = new Bitmap(SrcPicBox.Image, SrcPicBox.Width, SrcPicBox.Height);
                Graphics g = pictureBox3.CreateGraphics();
    
                //Draw the image on the Graphics object with the new dimesions
                g.DrawImage(sourceBitmap, new Rectangle(0, 0, pictureBox3.Width, pictureBox3.Height), rectCropArea, GraphicsUnit.Pixel);
                sourceBitmap.Dispose();
            }
