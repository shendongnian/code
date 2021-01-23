    using (var httpClient = new HttpClient() {Timeout = TimeSpan.FromMinutes(25)})
	using (var response = await httpClient.GetAsync(theDownloadUrl, HttpCompletionOption.ResponseHeadersRead))
	using (var videoFileStream = File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.Read)) {
		videoFileStream.SetLength(response.Content.Headers.ContentLength.GetValueOrDefault());
		var copying = response.Content.CopyToAsync(videoFileStream);
		//await Task.Delay(1000);
		MediaSource = fileName;
		await copying;
	}
