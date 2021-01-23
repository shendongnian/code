		public static byte[] Encrypt(byte[] data, AsymmetricKeyParameter key)
		{
			RsaEngine e = new RsaEngine();
			e.Init(true, key);
			int blockSize = e.GetInputBlockSize();
			List<byte> output = new List<byte>();
			for (int chunkPosition = 0; chunkPosition < data.Length; chunkPosition += blockSize)
			{
				int chunkSize = Math.Min(blockSize, data.Length - (chunkPosition * blockSize));
				output.AddRange(e.ProcessBlock(data, chunkPosition, chunkSize));
			}
			return output.ToArray();
		}
