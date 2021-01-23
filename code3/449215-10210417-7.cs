	public static class CompressedBinaryConverter
	{
		/// <summary>
		/// Converts any object into a byte array and then compresses it
		/// </summary>
		/// <param name="o">The object to convert</param>
		/// <returns>A compressed byte array that was the object</returns>
		public static byte[] ToByteArray(object o)
		{
			if (o == null)
				return new byte[0];
			using (MemoryStream outStream = new MemoryStream())
			{
				using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress))
				{
					using (MemoryStream stream = new MemoryStream())
					{
						new BinaryFormatter().Serialize(stream, o);
						stream.Position = 0;
						stream.CopyTo(zipStream);
						zipStream.Close();
						return outStream.ToArray();
					}
				}
			}
		}
		/// <summary>
		/// Converts a byte array back into an object and uncompresses it
		/// </summary>
		/// <param name="byteArray">Compressed byte array to convert</param>
		/// <returns>The object that was in the byte array</returns>
		public static object ToObject(byte[] byteArray)
		{
			if (byteArray.Length == 0)
				return null;
			using (MemoryStream decomStream = new MemoryStream(byteArray), ms = new MemoryStream())
			{
				using (GZipStream hgs = new GZipStream(decomStream, CompressionMode.Decompress))
				{
					hgs.CopyTo(ms);
					decomStream.Close();
					hgs.Close();
					ms.Position = 0;
					return new BinaryFormatter().Deserialize(ms);
				}
			}
		}
	}
