    	private const string SignatureZip = "50-4B-03-04";
		private const string SignatureGzip = "1F-8B-08";
		public static bool IsZip(this Stream stream)
		{
			if (stream.Position > 0)
			{
				stream.Seek(0, SeekOrigin.Begin);
			}
			bool isZip = CheckSignature(stream, 4, SignatureZip);
			bool isGzip = CheckSignature(stream, 3, SignatureGzip);
			bool isSomeKindOfZip = isZip || isGzip;
	
			if (isSomeKindOfZip && stream.IsPackage()) //Signature matches ZIP, but it's package format (docx etc).
			{
				return false;
			}
			return isSomeKindOfZip;
		}
		/// <summary>
		/// MS .docx, .xslx and other extensions are (correctly) identified as zip files using signature lookup.
		/// This tests if System.IO.Packaging is able to open, and if package has parts, this is not a zip file.
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		private static bool IsPackage(this Stream stream)
		{
			Package package = Package.Open(stream, FileMode.Open, FileAccess.Read);
			return package.GetParts().Any();
		}
