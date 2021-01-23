        internal ColorAdornment(ColorTag colorTag)
        {
            BitmapImage image = new BitmapImage(); 
            using (FileStream stream = File.OpenRead("c:\\temp\\sologo.png")) 
            { 
                image.BeginInit(); 
                image.StreamSource = stream; 
                image.CacheOption = BitmapCacheOption.OnLoad; 
                image.EndInit(); 
            }
            this.Content = new Image() { Margin = new Thickness(20,0,0,0), Width = 100, Height = 30, Source = image };
        }
