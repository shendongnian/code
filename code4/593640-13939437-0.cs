		struct RGB24bpp
		{
			public byte R;
			public byte G;
			public byte B;
			
			public static readonly int Size = 3;
		}
		struct RGBAf96bpp
		{
			public float R;
			public float G;
			public float B;
			
			public static readonly int Size = 12;
		}
		...
		var handle = GCHandle.Alloc(tempBuffer /* the raw byte[] */, GCHandleType.Pinned);
		try
		{
			var ptr = handle.AddrOfPinnedObject();
			var safeBuffer = new SafeMemoryMappedViewHandle(true /* I believe DetachPixelData returns a copy? false otherwise  */)
			safeBuffer.SetHandle(ptr);
			
			#if STREAM_PROCESSING
				// pixel by pixel
				int offset = 0;
				for (int i = 0; i < width * height; i++)
				{
					var pixel = safeBuffer.Read<RGB24bpp>(offset);
					offset += RGB24bpp.Size;
				}
			#else
				// Read it all in at once - this makes a copy
				var pixels = new RGB24[width * height];
				safeBuffer.ReadArray<RGB24bpp>(0, pixels, 0, width * height);
			#endif
		}
		finally
		{
			safeBuffer.Dispose();
			handle.Free;
		}
