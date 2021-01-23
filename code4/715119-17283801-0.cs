    try
    {
        return new BitmapImage(new Uri(file, UriKind.Relative));
    }
    catch (FileNotFoundException exception)
    {
        // log exception etc.
        return new BitmapImage(new Uri(genericfile, UriKind.Relative));
    }
    catch (Exception exception)
    {
        // handle other exceptions
    }
