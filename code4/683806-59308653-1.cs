csharp
ProgressMessageHandler processMessageHander = new ProgressMessageHandler();
processMessageHander.HttpSendProgress += (s, e) =>
{
	if (e.ProgressPercentage > 0)
	{
		ProgressPercentage = e.ProgressPercentage;
		TotalBytes = e.TotalBytes;
		progressAction?.Invoke(progressFile);
	}
};
using (var client = HttpClientFactory.Create(processMessageHander))
{
	var uri = new Uri(transfer.BackEndUrl);
	client.DefaultRequestHeaders.Authorization =
	new AuthenticationHeaderValue("Bearer", AccessToken);
	using (MultipartFormDataContent multiForm = new MultipartFormDataContent())
	{
		multiForm.Add(new StringContent(FileId), "FileId");
		multiForm.Add(new StringContent(FileName), "FileName");
		string hash = "";
		using (MD5 md5Hash = MD5.Create())
		{
			var sb = new StringBuilder();
			foreach (var data in md5Hash.ComputeHash(File.ReadAllBytes(FullName)))
			{
				sb.Append(data.ToString("x2"));
			}
			hash = result.ToString();
		}
		multiForm.Add(new StringContent(hash), "Hash");
		using (FileStream fs = File.OpenRead(FullName))
		{
			multiForm.Add(new StreamContent(fs), "file", Path.GetFileName(FullName));
			var response = await client.PostAsync(uri, multiForm);
			progressFile.Message = response.ToString();
			
			if (response.IsSuccessStatusCode) {
				progressAction?.Invoke(progressFile);
			} else {
				progressErrorAction?.Invoke(progressFile);
			}
			response.EnsureSuccessStatusCode();
		}
	}
}
