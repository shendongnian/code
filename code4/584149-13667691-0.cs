	Action<int> downloadFileAsync = i =>
	{
		var bd = AppDomain.CurrentDomain.BaseDirectory;
		var fn = bd + "/" + i + ".7z";
		var wc = new WebClient();
		DownloadProgressChangedEventHandler dpc = (s1, e1) =>
		{
			progressBar1.Value = e1.ProgressPercentage;
		};
		wc.DownloadProgressChanged += dpc;
		AsyncCompletedEventHandler dfc = null;
		dfc = (s, e) =>
		{
			wc.DownloadFileCompleted -= dfc;
			wc.DownloadProgressChanged -= dpc;
			CompressionEngine.Current.Decoder
				.DecodeIntoDirectory(fn, bd);
			File.Delete(fn);
			wc.Dispose();
		};
		wc.DownloadFileCompleted += dfc;
		wc.DownloadFileAsync(
			new Uri(Dlpath + i + "/" + i + ".7z"),
			fn);
	};
