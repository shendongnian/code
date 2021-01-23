        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            MaintainPictureBoxSize();
        }
        private void MaintainPictureBoxSize()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            if (pictureBox1.Image == null)
                pictureBox1.Size = this.Size;
            else
            {
                Size s = pictureBox1.Image.Size;
                pictureBox1.Size = new Size(
                    this.Width > s.Width ? this.Width : s.Width,
                    this.Height > s.Height ? this.Height : s.Height);
            }
        }
