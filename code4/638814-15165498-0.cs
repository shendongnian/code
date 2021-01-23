    private void btnOpen_Click(object sender, EventArgs e)
    {
         OpenFileDialog dlg = new OpenFileDialog()
         {
                dlg.Title = "Open Image";
                dlg.Filter = "bmp files (*.bmp)|*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PictureBox picBox = new PictureBox();
                    picBox.Location = drawingPanel.Location;
                    picBox.Size = drawingPanel.Size;
                    picBox.Image = new Bitmap (dlg.FileName);
                    this.Controls.Add(picBox);
                }
          }
      }
