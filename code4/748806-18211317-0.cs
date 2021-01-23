    // Determine the visibility of the dark background.
    Visibility darkBackgroundVisibility = 
        (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
    // Write the theme background value.
    if (darkBackgroundVisibility == Visibility.Visible)
    {
        textBlock1.Text = "background = dark";
    }
    else
    {
        textBlock1.Text = "background = light";
    }
