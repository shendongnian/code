    foreach (string image in images)
    {
       PictureBox picture = new PictureBox();
       picture.Image = new Bitmap(image); 
       someParentControl.Controls.Add(picture);
    }
