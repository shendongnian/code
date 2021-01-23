	sealed class Block
	{
		internal Block(int size)
		{
			Data = new byte[size];
		}
		~Block()
		{
			BlockFactory.Free(this);
			GC.ReRegisterForFinalize(this);
		}
		public byte[] Data
		{
			get;
			private set;
		}
	}
	static class BlockFactory
	{
		public static Block Allocate(int size)
		{
			lock (_freeBlocks)
			{
				foreach (Block block in _freeBlocks)
				{
					if (block.Data.Length == size)
					{
						_freeBlocks.Remove(block);
						
						return block;
					}
				}
				return new Block(size);
			}
		}
		internal static void Free(Block block)
		{
			lock (_freeBlocks) _freeBlocks.Add(block);
		}
		private static List<Block> _freeBlocks = new List<Block>();
	}
