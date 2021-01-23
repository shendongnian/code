csharp
private static async Task<object> Upload(string actionUrl)
{
	Image newImage = Image.FromFile(@"Absolute Path of image");
	ImageConverter _imageConverter = new ImageConverter();
	byte[] paramFileStream= (byte[])_imageConverter.ConvertTo(newImage, typeof(byte[]));
	var formContent = new MultipartFormDataContent
	{
		// Send form text values here
		{new StringContent("value1"),"key1"},
		{new StringContent("value2"),"key2" },
		// Send Image Here
		{new StreamContent(new MemoryStream(paramFileStream)),"imagekey","filename.jpg"}
	};
	var myHttpClient = new HttpClient();
	var response = await myHttpClient.PostAsync(actionUrl.ToString(), formContent);
	string stringContent = await response.Content.ReadAsStringAsync();
	return response;
}
