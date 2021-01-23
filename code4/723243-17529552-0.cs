	[StructLayout(LayoutKind.Sequential)]
	struct SDL_PixelFormat
	{
		UInt32 format;
		IntPtr palettePtr;
		byte BitsPerPixel;
		byte BytesPerPixel;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		byte padding[];
		UInt32 Rmask;
		UInt32 Gmask;
		UInt32 Bmask;
		UInt32 Amask;
		byte Rloss;
		byte Gloss;
		byte Bloss;
		byte Aloss;
		byte Rshift;
		byte Gshift;
		byte Bshift;
		byte Ashift;
		int refcount;
		IntPtr nextPtr;
	}
	[StructLayout(LayoutKind.Sequential)]
	struct SDL_Surface
	{
		public readonly UInt32 flags;
		public readonly IntPtr format;  
		public readonly int w, h;                  
		public readonly int pitch;               
		public IntPtr pixels;             
		/// <summary>Application data associated with the surface</summary>
		public IntPtr userdata;           
		/// <summary>information needed for surfaces requiring locks</summary>
		public readonly int locked;              
		public readonly IntPtr lock_data;           
		/// <summary>clipping information</summary>
		public readonly SDL_Rect clip_rect;        
		/// <summary>info for fast blit mapping to other surfaces</summary>
		private IntPtr mapPtr;
		/// <summary>Reference count -- used when freeing surface</summary>
		public int refcount;             
	}
	[StructLayout(LayoutKind.Sequential)]
	struct SDL_BlitMap
	{
		IntPtr dstPtr;
		int identity;
		SDL_blit blit;
		IntPtr data;
		SDL_BlitInfo info;
		/* the version count matches the destination; mismatch indicates
		   an invalid mapping */
		UInt32 dst_palette_version;
		UInt32 src_palette_version;
	}
	[StructLayout(LayoutKind.Sequential)]
	struct SDL_Rect
	{
		int x, y;
		int w, h;
	}
	[UnmanagedFunctionPointer(CallingConvention.ToBeAdded)]
	internal delegate int SDL_blit(ref SDL_Surface src, ref SDL_Rect srcrect, ref SDL_Surface dst, ref SDL_Rect dstrect);
