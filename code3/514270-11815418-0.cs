    Image newImage = Image.FromFile("view.jpg");
    Bitmap img = new Bitmap(newImage, 
                            (int)(newImage.Size.Width / ZoomLevel), 
                            (int)(newImage.Size.Height / ZoomLevel));
    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
    pictureBox1.Image = img;
