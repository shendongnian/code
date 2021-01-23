	Action<int> downloadFileAsync = i =>
	{
		var bd = AppDomain.CurrentDomain.BaseDirectory;
		var fn = bd + "/" + i + ".7z";
		var wc = new WebClient();
		DownloadProgressChangedEventHandler dpc = (s, e) =>
		{
			progressBar1.Value = e.ProgressPercentage;
		};
		AsyncCompletedEventHandler dfc = null;
		dfc = (s, e) =>
		{
			wc.DownloadProgressChanged -= dpc;
			wc.DownloadFileCompleted -= dfc;
			CompressionEngine.Current.Decoder.DecodeIntoDirectory(fn, bd);
			File.Delete(fn);
			wc.Dispose();
		};
		wc.DownloadProgressChanged += dpc;
		wc.DownloadFileCompleted += dfc;
		wc.DownloadFileAsync(new Uri(Dlpath + i + "/" + i + ".7z"), fn);
	};
