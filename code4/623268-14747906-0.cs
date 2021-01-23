    Bitmap image;
    using(var ms = new MemoryStream()) {
        fileUpload1.PostedFile.InputStream.CopyTo(ms);
        ms.Position = 0;
        image = new System.Drawing.Bitmap(ms);
    }
