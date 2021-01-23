    FileInfo imageFileinfo;           //add this
    //OpenFileDialog ofd = null;      Get rid of this
    private void button1_Click(object sender, EventArgs e)
    {
         if (System.IO.Directory.Exists(path))
         {
             OpenFileDialog ofd = new OpenFileDialog();  //make ofd local
             ofd.InitialDirectory = path;
             DialogResult dr = new DialogResult();
             if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
             {
                  Image img = new Bitmap(ofd.FileName);
                  imageFileinfo = new FileInfo(ofd.FileName);  // save the file name
                  string imgName = ofd.SafeFileName;
                  txtImageName.Text = imgName;
                  pictureBox1.Image = img.GetThumbnailImage(350, 350, null, new IntPtr());
                  ofd.RestoreDirectory = true;
                  img.Dispose();
             }
             ofd.Dispose();  //don't forget to dispose it!
         }
         else
         {
             return;
         }
     }
