	struct BoolCount
	{
		private readonly int c;
		private BoolCount(int c) { this.c = c; }
	
		public static implicit operator BoolCount(bool b)
			{ return new BoolCount(Convert.ToInt32(b)); }
			
		public static implicit operator int(BoolCount me)
			{ return me.c; }
			
		public static BoolCount operator +(BoolCount me, BoolCount other)
			{ return new BoolCount(me.c + other.c); }
	}
