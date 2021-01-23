    // Load you image data in MemoryStream
    TagLib.IPicture pic = f.Tag.Pictures[0];
    MemoryStream ms = new MemoryStream(pic.Data.Data);
    ms.Seek(0, SeekOrigin.Begin);
    // ImageSource for System.Windows.Controls.Image
    BitmapImage bitmap= new BitmapImage();
    bitmap.BeginInit();
    bitmap.StreamSource = ms;
    bitmap.EndInit();
    // Create a System.Windows.Controls.Image control
    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
    img.Source = bitmap;
