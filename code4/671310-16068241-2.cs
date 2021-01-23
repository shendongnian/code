    Image img;
    string file = @"d:\a.jpg";
    using (Bitmap bmp = new Bitmap(file))
    {
       img = new Bitmap(bmp);
       current_pic.Image = img;
    }
    if (File.Exists(file))
    {
        File.Delete(file);
        current_pic.Image.Save(file, ImageFormat.Jpeg);
    }
    else
        current_pic.Image.Save(file, ImageFormat.Jpeg);
