	[StructLayout(LayoutKind.Explicit, Size = 1, CharSet = CharSet.Ansi)]
	public struct Rgb16
	{
		#region Lifetime
		/// <summary>
		/// Ctor
		/// </summary>
		/// <param name="foo"></param>
		public Rgb16(int foo)
		{
			// allocate the bitfield
			buffer = new BitVector32(0);
			// initialize bitfield sections
			r = BitVector32.CreateSection(0x0f);        // 4
			g = BitVector32.CreateSection(0x1f, r);     // 5
			b = BitVector32.CreateSection(0x0f, g);     // 4
		}
		#endregion
		#region Bifield
		// Creates and initializes a BitVector32.
		[FieldOffset(0)]
		private BitVector32 buffer;
		#endregion
		#region Bitfield sections
		/// <summary>
		/// Section - Red
		/// </summary>
		private static BitVector32.Section r;
		/// <summary>
		/// Section - Green
		/// </summary>
		private static BitVector32.Section g;
		/// <summary>
		/// Section - Blue
		/// </summary>
		private static BitVector32.Section b;
		#endregion
		#region Properties
		/// <summary>
		/// Flag 1
		/// </summary>
		public byte R
		{
			get { return (byte)buffer[r]; }
			set { buffer[r] = value; }
		}
		/// <summary>
		/// Flag 2
		/// </summary>
		public byte G
		{
			get { return (byte)buffer[g]; }
			set { buffer[g] = value; }
		}
		/// <summary>
		/// Flag 1
		/// </summary>
		public byte B
		{
			get { return (byte)buffer[b]; }
			set { buffer[b] = value; }
		}
		#endregion
		#region ToString
		/// <summary>
		/// Allows us to represent this in human readable form
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"Name: {nameof(Rgb16)}{Environment.NewLine}Red: {R}: Green: {G} Blue: {B}  {Environment.NewLine}BitVector32: {buffer}{Environment.NewLine}";
		}
		#endregion
	}
