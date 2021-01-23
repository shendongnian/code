    public void ConvertBitmap()
    {
        BitmapImage img = null;
        try
        {
            img = Convert(// pass in your params);
    
            // do stuff with your img
        }
        finally
        {
            // dispose of the memorystream in case of exception
            if(img != null && img.StreamSource != null) img.SourceStream.Dispose();
        }
    }
