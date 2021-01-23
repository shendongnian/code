    public static async Task<UIImage> LoadImage(string imageUrl)
    {
                var httpClient = new HttpClient();
    
                var contents = await httpClient.GetByteArrayAsync(imageUrl);
                return UIImage.LoadFromData(NSData.FromArray(contents));
    }
