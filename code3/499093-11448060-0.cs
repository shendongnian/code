	void SaveAsIcon(Bitmap SourceBitmap, string FilePath)
	{
		FileStream FS = new FileStream(FilePath, FileMode.Create);
		// ICO header
		FS.WriteByte(0); FS.WriteByte(0);
		FS.WriteByte(1); FS.WriteByte(0);
		FS.WriteByte(1); FS.WriteByte(0);
		// Image size
		FS.WriteByte((byte)SourceBitmap.Width);
		FS.WriteByte((byte)SourceBitmap.Height);
		// Palette
		FS.WriteByte(0);
		// Reserved
		FS.WriteByte(0);
		// Number of color planes
		FS.WriteByte(0); FS.WriteByte(0);
		// Bits per pixel
		FS.WriteByte(32); FS.WriteByte(0);
		// Data size, will be written after the data
		FS.WriteByte(0);
		FS.WriteByte(0);
		FS.WriteByte(0);
		FS.WriteByte(0);
		// Offset to image data, fixed at 22
		FS.WriteByte(22);
		FS.WriteByte(0);
		FS.WriteByte(0);
		FS.WriteByte(0);
		// Writing actual data
		SourceBitmap.Save(FS, ImageFormat.Png);
		// Getting data length (file length minus header)
		long Len = FS.Length - 22;
		// Write it in the correct place
		FS.Seek(14, SeekOrigin.Begin);
		FS.WriteByte((byte)Len);
		FS.WriteByte((byte)(Len >> 8));
		FS.Close();
	}
