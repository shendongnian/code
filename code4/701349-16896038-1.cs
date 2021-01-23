    using(Image img = Image.FromFile(dlgFichier.FileName))
    {
        Image temp = (Image)new Bitmap((Image)img.Clone(), new Size((int)Math.Round(img.Width / ratio), (int)Math.Round(img.Height / ratio)));
        temp.Save("your path");
    }
