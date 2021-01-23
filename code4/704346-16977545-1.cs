    Image img =
        iTextSharp.text.Image.GetInstance(toSaveImage,
            System.Drawing.Imaging.ImageFormat.Tiff);
    Rectangle pagesize = new Rectangle(img.ScaledWidth, img.ScaledHeight);
    Document document = new Document(pagesize);
    img.setAbsolutePosition(0, 0);
    document.Add(img);
