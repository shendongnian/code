    result = new MemoryStream();
	using(var bucket = new DisposableBucket())
	{
		using (var zipFile = new ZipFile())
		{
			List<IDisposable> memStreams = new List<IDisposable>();
			
			for (int i = 0; i < files.Count(); i++)
			{
				System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
				Byte[] bytes = encoding.GetBytes(files[i]);
			
				var fs = bucket.Using(new MemoryStream(bytes));
				zipFile.AddEntry(fileNames[i], fs);
				
			}
			zipFile.Save(result);
		
		}
	}
