        private void button_Click(object sender, RoutedEventArgs e) 
        {
             random();
             background.DoSomething();
        }
        ImageBrush background ;
        private void random()
        {
             //other code
             background = new ImageBrush();
             background.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new                         Uri(actorUri,    UriKind.Relative));
             //other code
        }
