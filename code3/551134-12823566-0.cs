        public static void VerifyPdf(string coverFile)
		{
			ScrubPdf(coverFile);
			Approvals.Verify(new ExistingFileWriter(coverFile));
		}
		private static void ScrubPdf(string coverFile)
		{
			long location;
			using (var pdf = File.OpenRead(coverFile))
			{
				location = Find("/CreationDate (", pdf);
			}
			using (var pdf = File.OpenWrite(coverFile))
			{
				pdf.Seek(location, SeekOrigin.Begin);
				var original = "/CreationDate (D:20110426104115-07'00')";
				var desired = new System.Text.ASCIIEncoding().GetBytes(original);
				pdf.Write(desired, 0, desired.Length);
				pdf.Flush();
			}
		}
