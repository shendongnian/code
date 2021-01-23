    using (var ms = new MemoryStream())
    {
        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        SaveImage(ms.ToArray());
    }
