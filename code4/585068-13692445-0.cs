    WebClient client = new WebClient ();
    Uri uri = new Uri(address);
    client.UploadFileCompleted += new UploadFileCompletedEventHandler (UploadFileCallback2);
	 // Specify a progress notification handler.
	 client.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
    client.UploadFileAsync (uri, "POST", fileName);
    Console.WriteLine ("File upload started.");
}
