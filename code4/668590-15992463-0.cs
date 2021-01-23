	public static void RunBlob(ICloudBlob blob, string targetFilePath) {
		using (var fileStream = File.OpenWrite(targetFilePath)) {
			blob.DownloadToStream(fileStream);
		}
		var process = new Process() {StartInfo = new ProcessStartInfo(targetFilePath)};
		process.Start();
		process.WaitForExit(); // Optional
	}
