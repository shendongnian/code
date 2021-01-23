    // Download the bitmap data using an instance of WebClient class.
    using (WebClient webClient = new WebClient())
    {
        foreach (var url in urls)
        {
            byte[] bitmapData;
            bitmapData = webClient.DownloadData(url);
            // Bitmap data => bitmap => resized bitmap.            
            using (MemoryStream memoryStream = new MemoryStream(bitmapData))
            using (Bitmap bitmap = new Bitmap(memoryStream))
            using (Bitmap resizedBitmap = new Bitmap(bitmap, 50, 50))
            {
                // NOTE:
                // Resized bitmap must be disposed because the imageList.Images.Add() method
                // makes a copy (!) of the source bitmap!
                // For details, see http://stackoverflow.com/questions/9515759/                
                imageList.Images.Add(resizedBitmap);
            }
        }
    }
