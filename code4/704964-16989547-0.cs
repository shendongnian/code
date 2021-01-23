        private void cbxSizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureBoxSizeMode mode;
            Enum.TryParse<PictureBoxSizeMode>(cbxSizeMode.SelectedValue.ToString(), out mode);
            this.pictureBox1.SizeMode = mode;
            if (this.pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
            {
                using (PictureBox pb = new PictureBox())
                {
                    pb.Size = pictureBox1.Size;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.Image = _backImage;
                    Bitmap bmp = new Bitmap(pb.Size.Width, pb.Size.Height);
                    pb.DrawToBitmap(bmp, pb.ClientRectangle);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                    this.pictureBox1.Image = bmp;
                }
            }
            else
            {
                pictureBox1.Image = _backImage;
            }
        }
