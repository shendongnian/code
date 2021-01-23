    public async Task<UIImage> LoadImage (string imageUrl)
    		{
    			var httpClient = new HttpClient();
    
    			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync (imageUrl);
    
    			// await! control returns to the caller and the task continues to run on another thread
    			var contents = await contentsTask;
    
    			// load from bytes
    			return UIImage.LoadFromData (NSData.FromArray (contents));
    		}
