	private static byte[] CopyAndHash(string source, string target, Action<double> progress, Func<bool> isCanceled)
	{
		var sha512 = SHA512.Create();
		using (var targetStream = File.OpenWrite(target))
		using (var cryptoStream = new CryptoStream(targetStream, sha512, CryptoStreamMode.Write))
		using (var sourceStream = File.OpenRead(source))
		{
			byte[] buffer = new byte[81920];
			int read;
			while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0 && !isCanceled())
			{
				cryptoStream.Write(buffer, 0, read);
				progress?.Invoke((double) sourceStream.Length / sourceStream.Position * 100);
			}
		}
		File.SetAttributes(target, File.GetAttributes(source));
		var hash = sha512.Hash;
		sha512.Dispose();
		return hash;
	}
