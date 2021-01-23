    public static ImageBrush GetBackground()
    {
        var imageBrush = new ImageBrush();
    
        if ((Visibility)App.Current.Resources["PhoneLightThemeVisibility"] == Visibility.Visible)
        { 
            imageBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("/Images/Background1.png", UriKind.Relative))
            };
        }
        else
        {
            imageBrush = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("/Images/Background2.png", UriKind.Relative))
            };
        }
    
        return imageBrush;
    }
