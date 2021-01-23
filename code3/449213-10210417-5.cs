    public static class BinaryConverter
	{
		public static byte[] ToByteArray(object o)
		{
			if(o == null)
				return new byte[0];
			byte[] buffer;
			BinaryFormatter bformatter = new BinaryFormatter();
			using (MemoryStream stream = new MemoryStream())
			{
				bformatter.Serialize(stream, o);
				buffer = stream.ToArray();
				stream.Close();
			}
			
			return buffer;
		}
		public static object ToObject(byte[] byteArray)
		{
			if (byteArray.Length == 0)
				return null;
			object obj = null;
			BinaryFormatter bformatter = new BinaryFormatter();
			using (MemoryStream stream = new MemoryStream(byteArray))
			{
				obj = bformatter.Deserialize(stream);
				stream.Close();
			}
			return obj;
		}
	}
    public static class CompressedBinaryConverter 
	{
		public static byte[] ToByteArray(object o)
		{
			byte[] uncomp = BinaryConverter.ToByteArray(o);
			byte[] buffer;
			using (MemoryStream outStream = new MemoryStream())
			{
				using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress))
				{
					zipStream.Write(uncomp, 0, uncomp.Length);
					zipStream.Close();
					buffer = outStream.ToArray();
				}
			}
			return buffer;
		}
		public static object ToObject(byte[] byteArray)
		{
			if (byteArray.Length == 0)
				return null;
			byte[] uncomp;
			using (MemoryStream decomStream = new MemoryStream(byteArray))
			{
				using (GZipStream hgs = new GZipStream(decomStream, CompressionMode.Decompress))
				{
					using (MemoryStream ms = new MemoryStream())
					{
						hgs.CopyTo(ms);
						hgs.Close();
						uncomp = ms.ToArray();
					}
				}
			}
			return BinaryConverter.ToObject(uncomp);
		}
	}
