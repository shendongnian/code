    OpenFileDialog open = new OpenFileDialog();
    open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
    if (open.ShowDialog() == DialogResult.OK)
    {
        Image img = new Bitmap(open.FileName);
        System.IO.File.Copy(open.FileName, open.FileName.Split('.')[0]+"_Copy."+open.FileName.Split('.')[1]);
        //this is an example, you give it the name you want
        string imagename = open.SafeFileName;
        Txt_countrylogo.Text = imagename;
        pictureBox2.Image = img.GetThumbnailImage(340, 165, null, new IntPtr());
        open.RestoreDirectory = true;
    }
