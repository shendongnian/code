    private void CenterPictureBox(PictureBox picBox, Bitmap picImage) {
      picBox.Image = picImage;
      picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picImage.Width / 2),
                                  (picBox.Parent.ClientSize.Height / 2) - (picImage.Height / 2));
      picBox.Refresh();
    }
