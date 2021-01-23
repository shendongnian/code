    using(Image img = Image.FromFile(dlgFichier.FileName))
    {
        Image temp = (Image)new Bitmap((Image)img.Clone(), new Size(objDevice.LogoWidth, objDevice.LogoHeight));
        temp.Save("your path");
    }
