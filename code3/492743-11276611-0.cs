    // Winforms Image we want to get the WPF Image from...
    System.Drawing.Image imgWinForms = System.Drawing.Image.FromFile("test.png");
        
    // ImageSource ...
    BitmapImage bi = new BitmapImage();
    bi.BeginInit();
    MemoryStream ms = new MemoryStream();
    
    // Save to a memory stream...
    imgWinForms.Save(ms, ImageFormat.Bmp);
    
    // Rewind the stream...    
    ms.Seek(0, SeekOrigin.Begin);
    
    // Tell the WPF image to use this stream...
    bi.StreamSource = ms;
    bi.EndInit();
