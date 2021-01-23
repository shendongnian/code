    string uploadUri = "http://www.myuri.com";
    
    WebClient webClient = new WebClient();
    
    // What to do when write stream is open
    webClient.OpenWriteCompleted += (s, args) =>
    {
    	var writeableBitmap = new WriteableBitmap(bitmapImage);
    	// Write the encoded image into the result stream
    	Extensions.SaveJpeg(
    		writeableBitmap,
    		args.Result,
    		bitmapImage.PixelWidth,
    		bitmapImage.PixelHeight,
    		0,
    		100);
    };
    
    // What to do when writing is complete
    webClient.WriteStreamClosed += (s, args) =>
    {
    	MessageBox.Show("Upload Complete");
    };
    
    // Write async to the WebClient
    webClient.OpenWriteAsync(new Uri(uploadUri), "POST");
