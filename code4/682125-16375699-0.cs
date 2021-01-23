        private void Form1_Load(object sender, EventArgs e)
        {
            // perform this for all your PictureBox pieces:
            this.ClipPictureBoxPiece(this.kpcKnight);
            // ...
            // ...
        }
        private void ClipPictureBoxPiece(PictureBox pb)
        {
            if (pb != null && pb.Image != null)
            {
                System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
                using (Bitmap bmp = new Bitmap(pb.Image))
                {
                    Color mask = bmp.GetPixel(0, 0);
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int y = 0; y < bmp.Height; y++)
                        {
                            if (!bmp.GetPixel(x, y).Equals(mask))
                            {
                                gp.AddRectangle(new Rectangle(x, y, 1, 1));
                            }
                        }
                    }
                }
                pb.Region = new Region(gp);
            }
        }
