        private void SetWallpaperButton_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                using (var img = Image.FromFile(openFileDialog1.FileName)) {
                    if (this.BackgroundImage != null) this.BackgroundImage.Dispose();
                    this.BackgroundImage = new Bitmap(img);
                }
            }
        }
