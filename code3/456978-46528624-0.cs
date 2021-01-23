    		private async Task<Stream> ReadStream()
		{
			Stream stream = null;
			var provider = new MultipartMemoryStreamProvider();
			await Request.Content.ReadAsMultipartAsync(provider);
			foreach (var file in provider.Contents)
			{
				var buffer = await file.ReadAsByteArrayAsync();
				stream = new MemoryStream(buffer);
			}
			return stream;
		}
    private async Task<Stream> ReadLargeStream()
		{
			Stream stream = null;
			string root = Path.GetTempPath();
			var provider = new MultipartFormDataStreamProvider(root);
			await Request.Content.ReadAsMultipartAsync(provider);
			foreach (var file in provider.FileData)
			{
				var path = file.LocalFileName;
				byte[] content = File.ReadAllBytes(path);
				File.Delete(path);
				stream = new MemoryStream(content);
			}
			return stream;
		}
