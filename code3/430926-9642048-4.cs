    string uploadUri = "http://www.myuri.com";
    
    WebClient webClient = new WebClient();
    
    // This event will be raised when we are ready to send data to the server
    webClient.OpenWriteCompleted += (s, args) =>
    {
        var writeableBitmap = new WriteableBitmap(bitmapImage);
        // Write the encoded image into the result stream
        writeableBitmap.SaveJpeg(
            args.Result,
            bitmapImage.PixelWidth,
            bitmapImage.PixelHeight,
            0,
            100);
    };
    
    // This event will be raised when writing is completed
    webClient.WriteStreamClosed += (s, args) =>
    {
        MessageBox.Show("Upload Complete");
    };
    // Write to the WebClient
    webClient.OpenWriteAsync(new Uri(uploadUri), "POST");
