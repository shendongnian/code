		private byte[] ReadWebResponse(WebResponse response)
		{
			byte[] bytes = null;
			if(response == null) return null;
			using(Stream responseStream = response.GetResponseStream())
			{
				using(BinaryReader readStream = new BinaryReader(responseStream))
				{
					using(MemoryStream memoryStream = new MemoryStream())
					{
						byte[] buffer = new byte[256];
						int count;
						int totalBytes = 0;
						while((count = readStream.Read(buffer, 0, 256)) > 0)
						{
							memoryStream.Write(buffer, 0, count);
							totalBytes += count;
						}
						memoryStream.Position = 0;
						bytes = new byte[totalBytes];
						memoryStream.Read(bytes, 0, totalBytes);
					}
				}
			}
			return bytes;
		}
