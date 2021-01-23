      var fd = new SaveFileDialog();
      fd.Filter = "Bmp(*.BMP;)|*.BMP;| Jpg(*Jpg)|*.jpg";
      fd.AddExtension = true;
      if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
          switch (Path.GetExtension(fd.FileName).ToUpper())
          {
              case ".BMP":
                   pictureBox2.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                   break;
              case ".JPG":
                   pictureBox2.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                   break;
              case ".PNG":
                   pictureBox2.Image.Save(fd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                   break;
              default:
                   break;
            }
    }
