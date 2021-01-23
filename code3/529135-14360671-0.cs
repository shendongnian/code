		// the *real* width and height of your form, Width and Height are now lying...
		internal int CoreWidth { get; private set; }
		internal int CoreHeight { get; private set; }
		// just for fun :
		public new int Width { get { return CoreWidth; } }
		public new int Height { get { return CoreHeight; } }
		protected override void SetClientSizeCore ( int x, int y )
		{
			// get wished width and height earlier enough in the chain of calls
			CoreWidth = x;
			CoreHeight = y;
			base.SetClientSizeCore ( x, y );
		}
		protected override void SetBoundsCore ( int x, int y, int width, int height, BoundsSpecified specified )
		{
			// don't trust width and height that are provided, use the ones you kept
			base.SetBoundsCore ( x, y, CoreWidth, CoreHeight, specified );
		}
