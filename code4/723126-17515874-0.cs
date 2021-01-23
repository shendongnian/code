    int newWidth = 75;
    int newHeight = 50;
    for (int i = 0; i < trees.Length; i++)
    {
        string d = imagePath + trees[i].latinName + ".JPG";
        Image image = Image.FromFile(d);
        //new image with size you need
        Bitmap smallImage = new Bitmap(newWidth, newHeight);
        Graphics g = Graphics.FromImage(smallImage);
        //draw scaled old image to new with correct size
        //g.drawImage(Image sourceImage, Rectangle destination, Rectangle source, GraphicsUnit gu)
        g.DrawImage(image, new Rectangle(0, 0, smallImage.Width, smallImage.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
        //format of new image is defined by it's name (.png/.jpg)
        smallImage.Save(trees[i].latinName + "_new.png");
    }
