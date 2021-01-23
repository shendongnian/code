    string imgPath = string.Format("{0}{1}.jpg", pngOutputPath, i);
    // Retrieve image from file
    Image img = Image.FromFile(imgPath);
    // Create new canvas to paint the picture in
    Bitmap tempImg = new Bitmap(img.Width, img.Height);
    // Paint image in memory
    using (Graphics g = Graphics.FromImage(tempImg))
    {
       g.DrawImage(img, 0, 0);
    }
    // Assign image to PictureBox
    pb.Image = tempImg;
    // Dispose original image and free handles
    img.Dispose();
    // Delete the original file
    File.Delete(imgPath);
