    private void button1_Click(object sender, EventArgs e)
    {
      Image imageFile;
      OpenFileDialog dlg = new OpenFileDialog();
            
      dlg.Title = "Open Image";
      dlg.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            
      if (dlg.ShowDialog() == DialogResult.OK)
         {
          imageFile = Image.FromFile(dlg.FileName);
          imgHeight = imageFile.Height;
          if (imgHeight > 350)
             {
                  MessageBox.Show("Not 350x350 Image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    imgPhoto.Image = null;
             }
             else
             {
               imgPhoto.Image = new Bitmap(dlg.OpenFile());
             }
          }
      dlg.Dispose();
    }
