    private void button1_Click(object sender, EventArgs e) {
        Image image = Bitmap.FromFile("C:\\Users\\Public\\Pictures\\Sample Pictures\\Desert.jpg");
        Bitmap watermarkImage = Bitmap.FromFile("C:\\Users\\Public\\Pictures\\Sample Pictures\\watermark.png");
        Graphics imageGraphics = Graphics.FromImage(image);
        watermarkImage.SetResolution(imageGraphics.DpiX, imageGraphics.DpiY);
        int x = ((image.Width - watermarkImage.Width) / 2);
        int y = ((image.Height - watermarkImage.Height) / 2);
        imageGraphics.DrawImage(watermarkImage, x, y, watermarkImage.Width, watermarkImage.Height);
        image.Save("C:\\Users\\Public\\Pictures\\Sample Pictures\\Desert_watermark.jpg");
    }
