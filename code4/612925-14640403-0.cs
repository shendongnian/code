     private void bg1_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Media.ImageBrush myBrush = new System.Windows.Media.ImageBrush();
            Image image = new Image();
            image.ImageFailed += (s, i) => MessageBox.Show("Failed to load: " + i.ErrorException.Message);
            image.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(@"/Assets/bg/bg1.jpg/", UriKind.RelativeOrAbsolute));
            myBrush.ImageSource = image.Source;
            grid1.Background = myBrush;
         
        }
