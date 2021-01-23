    private void DownloadFile(string url, string file)
		{
			byte[] result;
			byte[] buffer = new byte[4096];
			WebRequest wr = WebRequest.Create(url);
			wr.ContentType = "application/x-bittorrent";
			using (WebResponse response = wr.GetResponse())
			{
				bool gzip = response.Headers["Content-Encoding"] == "gzip";
				var responseStream = gzip
				                     	? new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)
				                     	: response.GetResponseStream();
				using (MemoryStream memoryStream = new MemoryStream())
				{
					int count = 0;
					do
					{
						count = responseStream.Read(buffer, 0, buffer.Length);
						memoryStream.Write(buffer, 0, count);
					} while (count != 0);
					result = memoryStream.ToArray();
					using (BinaryWriter writer = new BinaryWriter(new FileStream(file, FileMode.Create)))
					{
						writer.Write(result);
					}
				}
			}
		}
