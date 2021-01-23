    public static void CompressExistingDocument(string original, string output)
    {
    	using (PdfDocument pdf = new PdfDocument(original))
    	{
    		pdf.SaveOptions.Compression = PdfCompression.Flate;
    		pdf.SaveOptions.UseObjectStreams = true;
    		pdf.SaveOptions.RemoveUnusedObjects = true;
    		pdf.SaveOptions.WriteWithoutFormatting = true;
    
    		pdf.Save(output);
    	}
    
    	FileInfo originalFileInfo = new FileInfo(original);
    	FileInfo compressedFileInfo = new FileInfo(output);
    	MessageBox.Show(
    		String.Format("Original file size: {0} bytes;\r\nCompressed file size: {1} bytes",
    		originalFileInfo.Length, compressedFileInfo.Length));
    
    	System.Diagnostics.Process.Start(output);
    }
