    bool DarkThemeUsed ()
    { 
         return Visibility.Visible ==   (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
    }
 
    bool LightThemeUsed() 
    {
         return Visibility.Visible == (Visibility)Application.Current.Resources["PhoneLightThemeVisibility"];
    }
