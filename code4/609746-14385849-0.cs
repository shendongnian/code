      private void button_Click(object sender, RoutedEventArgs e) 
      {
         random();
         background.SomeMethod();
      }
      ImageBrush background = new ImageBrush();
      private void random()
      {
         //other code
         background.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new                         Uri(actorUri,    UriKind.Relative));
         //other code
       }
