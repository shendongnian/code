    private void btnShow_Click(object sender, RoutedEventArgs e)
    {
      // DataTable dt2 = reqBll.SelectImage().Tables[0];
      // byte[] data = (byte[]) dt2.Rows[0][1];
      // MemoryStream strm = new MemoryStream();
      // strm.Write(data, 0, data.Length);
      System.Drawing.Image bmp = System.Drawing.Bitmap.FromFile(@"C:\Temp\test.png");
      MemoryStream strm = new MemoryStream();
      bmp.Save(strm, System.Drawing.Imaging.ImageFormat.Bmp);
      strm.Position = 0;
      System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
      BitmapImage bi = new BitmapImage();
      bi.BeginInit();
      MemoryStream ms = new MemoryStream();
      img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
      ms.Seek(0, SeekOrigin.Begin);
      bi.StreamSource = ms;
      bi.EndInit();
      imgBox.Source = bi;
    }
