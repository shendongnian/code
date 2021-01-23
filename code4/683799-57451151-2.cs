csharp
public async Task<object> PassImageWithText(IFormFile files)
{
	byte[] data;
	string result = "";
	ByteArrayContent bytes;
	MultipartFormDataContent multiForm = new MultipartFormDataContent();
	
	try
	{
		using (var client = new HttpClient())
		{
			using (var br = new BinaryReader(files.OpenReadStream()))
			{
				data = br.ReadBytes((int)files.OpenReadStream().Length);
			}
			bytes = new ByteArrayContent(data);
			multiForm.Add(bytes, "files", files.FileName);
			multiForm.Add(new StringContent("value1"), "key1");
			multiForm.Add(new StringContent("value2"), "key2");
			var res = await client.PostAsync(_MEDIA_ADD_IMG_URL, multiForm);
		}
	}
	catch (Exception e)
	{
		throw new Exception(e.ToString());
	}
	
	return result;
}
