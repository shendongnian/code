    Image newImage = Image.FromFile("view.jpg");
    pictureBox1.Width = (int)(newImage.Size.Width / 1);
    pictureBox1.Height = (int)(newImage.Size.Height / 1);
    
    Bitmap img = new Bitmap(newImage, 
                            (int)(newImage.Size.Width / ZoomLevel), 
                            (int)(newImage.Size.Height / ZoomLevel));
    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
    pictureBox1.Image = img;
