    byte[] bitmap = GetYourImage();
    using(Image image = Image.FromStream(new MemoryStream(bitmap)))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);  // Or Png
    }
