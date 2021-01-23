	abstract class Expander
	{
		private const int ZIP_LEAD_BYTES = 0x04034b50;
		private const ushort GZIP_LEAD_BYTES = 0x8b1f;
		public abstract MemoryStream Expand(Stream stream);	
		
		internal static bool IsPkZipCompressedData(byte[] data)
		{
			Debug.Assert(data != null && data.Length >= 4);
			// if the first 4 bytes of the array are the ZIP signature then it is compressed data
			return (BitConverter.ToInt32(data, 0) == ZIP_LEAD_BYTES);
		}
		internal static bool IsGZipCompressedData(byte[] data)
		{
			Debug.Assert(data != null && data.Length >= 2);
			// if the first 2 bytes of the array are theG ZIP signature then it is compressed data;
			return (BitConverter.ToUInt16(data, 0) == GZIP_LEAD_BYTES);
		}
		public static bool IsCompressedData(byte[] data)
		{
			return IsPkZipCompressedData(data) || IsGZipCompressedData(data);
		}
		public static Expander GetExpander(Stream stream)
		{
			Debug.Assert(stream != null);
			Debug.Assert(stream.CanSeek);
			stream.Seek(0, 0);
			try
			{
				byte[] bytes = new byte[4];
				stream.Read(bytes, 0, 4);
				if (IsGZipCompressedData(bytes))
					return new GZipExpander();
				if (IsPkZipCompressedData(bytes))
					return new ZipExpander();
				return new NullExpander();
			}
			finally
			{
				stream.Seek(0, 0);	// set the stream back to the begining
			}
		}
	}
