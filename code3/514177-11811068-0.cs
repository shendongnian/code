    // Download the bitmap data using an instance of WebClient class.
    byte[] bitmapData;
    using (WebClient webClient = new WebClient())
    {
        bitmapData = webClient.DownloadData("... your url here ...");
    }
    // Bitmap data => bitmap => resized bitmap.
    Bitmap resizedBitmap;
    using (MemoryStream memoryStream = new MemoryStream(bitmapData))
    using (Bitmap bitmap = new Bitmap(memoryStream))
        resizedBitmap = new Bitmap(bitmap, 50, 50);
    
    imageList.Images.Add(resizedBitmap);
