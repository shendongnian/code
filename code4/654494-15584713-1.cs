    List<ImageAndThumb> Images = new List<ImageAndThumb>();
      private void LoadBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog newDialog = new OpenFileDialog();
            if (newDialog.ShowDialog() == DialogResult.OK)
            {
                Images.Clear();
    
                string dirPath  = System.IO.Path.GetDirectoryName(newDialog.FileName.ToLower()); 
                DirectoryInfo di = new DirectoryInfo(dirPath);
                FileInfo[] finfos = di.GetFiles("*.*");
    
                foreach (FileInfo fi in finfos)
                {
                    string ext = fi.Extension.ToLower();
                    if ((ext.Equals(".png")) || (ext.Equals(".jpg")) || (ext.Equals(".tif")) ||                  (ext.Equals(".gif")))
                    {
                        string Filename = fi.FullName;
                        ImageAndThumb image = new ImageAndThumb(Filename); 
                        Images.Add(image);
                    }
                } 
            }
    
            pictureBox3.Image = Images[0].Thumb; // << Much less memory usage;
    
        }
