    Button[] cardButtons = new Button[52];
    for(int i = 0; i < 52; i++)
    {
       Uri uri = new Uri("/images/someImage.png", UriKind.Relative);  
       BitmapImage imgSource = new BitmapImage(uri);
       Image image = new Image();
       image.Source = imgSource;
       cardButtons [i] = new Button();
       cardButtons[i].Content = image;
    }
