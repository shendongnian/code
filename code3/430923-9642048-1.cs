    string uploadUri = "http://www.myuri.com";
    
    byte[] content = bitmapImage.ConvertToBytes();
    
    var webClient = new WebClient();
    
    // What to do when write stream is open
    webClient.OpenWriteCompleted += (s, args) =>
    {
    	using (var binaryWriter = new BinaryWriter(args.Result))
    	{
    		binaryWriter.Write(content);
    	}
    };
    
    // What to do when writing is complete
    webClient.WriteStreamClosed += (s, args) =>
    {
    	MessageBox.Show("Upload Complete");
    };
    
    // Write to the WebClient
    webClient.OpenWriteAsync(new Uri(uploadUri), "POST");
