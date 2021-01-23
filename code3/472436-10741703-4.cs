     private void button1_Click(object sender, EventArgs e)
        {
            using (Graphics G = pictureBox1.CreateGraphics())
            {
                G.DrawRectangle(Pens.Blue, 10, 10, 10, 10);
            }
            Bitmap BMP = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height,
                                            PixelFormat.Format32bppArgb);
            using (Graphics GFX = Graphics.FromImage(BMP))
            {
                GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                    Screen.PrimaryScreen.Bounds.Y,
                                    0, 0,
                                    Screen.PrimaryScreen.Bounds.Size,
                                    CopyPixelOperation.SourceCopy);
            }
            Bitmap YourPictureBoxImage = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(YourPictureBoxImage))
            {
                Point np = pictureBox1.PointToScreen(new Point(0, 0));
                g.DrawImage(BMP,new Rectangle(0,0,100,100),new Rectangle(np,pictureBox1.Size),GraphicsUnit.Pixel);
            }
            this.BackgroundImage = YourPictureBoxImage;
        }
