    CreateThumbnail(filename, _frontBitmap.Clone());
...
    void CreateThumbnail(string filename, BitmapSource image5)
    {
        if (filename != string.Empty)
        {
             using (FileStream stream5 = new FileStream(filename, FileMode.Create))
             {
                 PngBitmapEncoder encoder5 = new PngBitmapEncoder();
                 encoder5.Frames.Add(BitmapFrame.Create(image5));
                 encoder5.Save(stream5);
             }
        }
     }
