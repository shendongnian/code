        foreach(string x in files)
        {
            string imgIndex = x.Remove(0,x.LastIndexOf("_")+1).Remove(1);
            PictureBox pic = pictureBox1; 
            //...
            if (pic.Image != null) pic.Image.Dispose();
            pic.Image = null;
            pic.ImageLocation = x;
        }
