     // Detecting the current theme. 
        
        private static Color lightThemeBackground = Color.FromArgb(255, 255, 255, 255); 
    private static Color darkThemeBackground = Color.FromArgb(255, 0, 0, 0); 
    rivate static SolidColorBrush backgroundBrush; 
    
    internal static AppTheme CurrentTheme 
        {
            get
            {
               if ( backgroundBrush == null )
                   backgroundBrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
             
               if (backgroundBrush.Color == lightThemeBackground)
                    return AppTheme.Light;
               else if (backgroundBrush.Color == darkThemeBackground)
                    return AppTheme.Dark;
             
               return AppTheme.Dark;
            } 
        }
