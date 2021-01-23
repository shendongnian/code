    string YourDir = "Images\\";
    List<Image> MyImgList = new List<Image>();
    string[] images = System.IO.Directory.GetFiles(YourDir);
    images = images.Where(F => ImageExtensions.Contains(System.IO.Path.GetExtension(F))).ToArray();
    foreach (string Img in images) {
	   BitmapImage bmp = new BitmapImage();
	   bmp.BeginInit();
	   bmp.UriSource = new Uri(Img, UriKind.Relative);
	   bmp.EndInit();
	   MyImgList.Add(new Image { Source = bmp });
    }
