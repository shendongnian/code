    private void bg6_Click(object sender, RoutedEventArgs e)
    {
      System.Windows.Media.ImageBrush myBrush = new System.Windows.Media.ImageBrush();
      Image image = new Image();
      image.ImageFailed += (s, e) => MessageBox.Show("Failed to load: " + e.ErrorException.Message);
      image.Source = new System.Windows.Media.Imaging.BitmapImage(
      new Uri("\\PhoneApp2\\PhoneApp2\\Assets\\bg\\bg5.jpg"));
      myBrush.ImageSource = image.Source;
      // Grid grid1 = new Grid();
      grid1.Background = myBrush;          
    }
