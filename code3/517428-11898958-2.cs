    public static void Navigate(string url, object obj = null) 
    {
        // Saves the object
        passedObject = obj;
        if( url != null && url.length > 0 )
        {
            // Creates the Uri-object
            Uri uri = new Uri(url, UriKind.Relative);
            // Navigates the user (notice the funky syntax - so that this can be used from any project
            (Application.Current.RootVisual as PhoneApplicationFrame).Navigate(uri);
        }
    }
    
