      private void button_Click(object sender, RoutedEventArgs e) 
      {
         ImageBrush bg = random();
         bg.SomeMethod()
         
      }
      
      private ImageBrush random()
      {
         //other code
         ImageBrush background = new ImageBrush();
         background.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new                         Uri(actorUri,    UriKind.Relative));
         //other code
         return background;
       }
