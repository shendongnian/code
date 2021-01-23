    string directory = @".\card_images\";
    List<Image> HandCards = new List<Image>();
    foreach (string myFile in
              Directory.GetFiles(directory, "*.png", SearchOption.AllDirectories))
    {
        Image image = new Image();
        BitmapImage source = new BitmapImage();
        source.BeginInit();
        source.UriSource = new Uri(myFile, UriKind.Relative);
        source.EndInit();
        image.Source = source;
        HandCards.Add(image);
    }
