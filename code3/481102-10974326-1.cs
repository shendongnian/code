	struct PreferencedDecisionMaker
	{
		private uint availableOptionsBits;
		private static readonly int[] MultiplyDeBruijnBitPosition = {
			0, 1, 28, 2, 29, 14, 24, 3, 30, 22, 20, 15, 25, 17, 4, 8, 
			31, 27, 13, 23, 21, 19, 16, 7, 26, 12, 18, 6, 11, 5, 10, 9
		};
		public int Decision
		{
			get
			{
				uint v = availableOptionsBits;
				// Find position of lowest set bit in constant time
				// http://stackoverflow.com/a/757266/165500
				return MultiplyDeBruijnBitPosition[((uint)((v & -v) * 0x077CB531U)) >> 27];
			}
		}
		private void InternalPush(uint preference)
		{
			if(availableOptionsBits == 0)
				availableOptionsBits = preference;
			else
			{
				uint combinedBits = availableOptionsBits & preference;
				if(combinedBits != 0)
					availableOptionsBits = combinedBits;
			}
		}
		public void Push(int option)
		{
			if(option < 0 || option >= 32) throw new ArgumentOutOfRangeException("Option must be between 0 and 31");
			InternalPush(1u << option);
		}
		// ... etc ...
		public void Push(bool p0, bool p1, bool p2, bool p3, bool p4) { InternalPush((p0?1u:0u) | ((p1?1u:0u)<<1) | ((p2?1u:0u)<<2) | ((p3?1u:0u)<<3) | ((p4?1u:0u)<<4)); }
		// ... etc ...
	}
