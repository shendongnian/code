        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            MaintainPictureBoxSize();
        }
        private void MaintainPictureBoxSize()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            var clientSize = this.ClientSize;
            pictureBox1.Location = new Point();
            if (pictureBox1.Image == null)
                pictureBox1.Size = clientSize;
            else
            {
                Size s = pictureBox1.Image.Size;
                pictureBox1.Size = new Size(
                    clientSize.Width > s.Width ? clientSize.Width : s.Width,
                    clientSize.Height > s.Height ? clientSize.Height : s.Height);
            }
        }
