    foreach (char i in stringArr)
    {
        PictureBox pictureBox = new PictureBox();
        object obj = ResourceManager.GetObject(i.ToString(), resourceCulture);
        pictureBox.Image = ((System.Drawing.Bitmap)(obj));
    }
